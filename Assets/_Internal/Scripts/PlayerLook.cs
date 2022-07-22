using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    private float yRotation = 0f;

    public float xSensitivity = 0.25f;
    public float ySensitivity = 0.25f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        float mouseX = input.x;
        float mouseY = input.y;

        Debug.Log(mouseX);
        Debug.Log(mouseY);

        xRotation = cam.transform.localRotation.eulerAngles.x;
        xRotation -= mouseY * ySensitivity;

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(new Vector3(0, mouseX * xSensitivity, 0));
    }
}
