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
        if (Input.GetKey(forward))
        {
            transform.Translate(transform.forward * keyboardSensitivity * Time.deltaTime);
        }

        if (Input.GetKey(backward))
        {
            transform.Translate(-transform.forward * keyboardSensitivity * Time.deltaTime);
        }

        if (Input.GetKey(strafeLeft))
        {
            transform.Translate(-transform.right * keyboardSensitivity * Time.deltaTime);
        }

        if (Input.GetKey(strafeRight))
        {
            transform.Translate(transform.right * keyboardSensitivity * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            float horizontal = Input.GetAxis("Mouse X") * mouseLookSensitivity;
            transform.Rotate(transform.up * horizontal, Space.World);
        }
    }
}
