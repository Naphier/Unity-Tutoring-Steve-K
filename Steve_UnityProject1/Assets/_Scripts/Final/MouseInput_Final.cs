using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour
{
    public float rotateWithMouseSensitivty = 5f;
    public float moveWithMouseSensitivity = 1f;
    private float horizontal, vertical;
    public enum InputStyle { rotateWithMouseLocal, rotateWithMouseGlobal, moveWithMouse, mouseDrag}
    public InputStyle inputStyle = InputStyle.rotateWithMouseLocal;
    public Vector3 initialPosition;
    public Quaternion initialRotation;

    void Start()
    {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;
    }

    void FixedUpdate()
    {
        switch (inputStyle)
        {
            case InputStyle.rotateWithMouseLocal:
                RotateWithMouseLocal();              
                break;
            case InputStyle.rotateWithMouseGlobal:
                RotateWithMouseGlobal();
                break;

            case InputStyle.moveWithMouse:
                MoveWithMouse();
                break;
        }

        if (Input.GetKey(KeyCode.P))
        {
            gameObject.transform.position = initialPosition;
            gameObject.transform.rotation = initialRotation;
        }
    }


    void RotateWithMouseLocal()
    {
        if (Input.GetMouseButton(0))
        {
            horizontal = -Input.GetAxis("Mouse X") * rotateWithMouseSensitivty;
            vertical = Input.GetAxis("Mouse Y") * rotateWithMouseSensitivty;
            gameObject.transform.Rotate(new Vector3(vertical, horizontal, 0f));
        }
    }


    void RotateWithMouseGlobal()
    {
        if (Input.GetMouseButton(0))
        {
            horizontal = -Input.GetAxis("Mouse X") * rotateWithMouseSensitivty;
            vertical = Input.GetAxis("Mouse Y") * rotateWithMouseSensitivty;
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.right, vertical);
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, horizontal);
        }
    }



    Vector2 mouseStart;
    bool mouseStartSet = false;
    void MoveWithMouse()
    {
        

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = (Vector3)Input.mousePosition;
            mousePosition.z = gameObject.transform.position.z - Camera.main.transform.position.z;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (!mouseStartSet)
            {
                mouseStartSet = true;
                mouseStart = mouseWorldPosition;
            }
            Vector3 deltaMousePosition = mouseWorldPosition - (Vector3)mouseStart;
            mouseStart = mouseWorldPosition;
            gameObject.transform.position += deltaMousePosition * moveWithMouseSensitivity;
        }
        else
            mouseStartSet = false;
        

    }

    //Can be used with any object that has a collider
    void OnMouseDrag()
    {
        if (inputStyle != InputStyle.mouseDrag)
            return;

        Vector3 mousePosition = (Vector3)Input.mousePosition;
        mousePosition.z = gameObject.transform.position.z - Camera.main.transform.position.z;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = gameObject.transform.position.z;
        gameObject.transform.position = mouseWorldPosition;
    }
}
