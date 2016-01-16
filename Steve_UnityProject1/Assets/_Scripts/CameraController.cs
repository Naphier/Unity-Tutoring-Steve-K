using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float mouseLookSensitivity = 1f;
    public float keyboardSensitivity = 1f;

    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode strafeLeft = KeyCode.A;
    public KeyCode strafeRight = KeyCode.D;


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(forward) || v > 0.1f)
        {
            transform.Translate(Vector3.forward * keyboardSensitivity * Time.deltaTime);
        }

        if (Input.GetKey(backward) || v < -0.1f)
        {
            transform.Translate(-Vector3.forward * keyboardSensitivity * Time.deltaTime);
        }

        if (Input.GetKey(strafeLeft) || h < -0.1f)
        {
            transform.Translate(-Vector3.right * keyboardSensitivity * Time.deltaTime);
        }

        if (Input.GetKey(strafeRight) || h > 0.1f)
        {
            transform.Translate(Vector3.right * keyboardSensitivity * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            float horizontal = Input.GetAxis("Mouse X") * mouseLookSensitivity;
            transform.Rotate(transform.up * horizontal, Space.World);
        }


        float rightThumbHorizontal = Input.GetAxis("axis 3");
        if (Mathf.Abs(rightThumbHorizontal) > 0.01f)
        {
            transform.Rotate(transform.up * rightThumbHorizontal, Space.World);
        }
    }
}
