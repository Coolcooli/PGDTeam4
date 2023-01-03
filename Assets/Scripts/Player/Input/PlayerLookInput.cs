using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLookInput : MonoBehaviour
{
    private Camera playerCamera;
    private float cameraRotation;
    [SerializeField]
    [Range(1, 5f)]
    float mouseSensitivity = 1.5f;
    private bool allowLookInput = true;
    public bool AllowLookInput { get { return allowLookInput; } set { allowLookInput = value; } }

    private void Start()
    {
        playerCamera = Camera.main;
    }

    /// <summary>
    /// Rotates the player body and camera based on mouse input
    /// </summary>
    /// <param name="context">Vector2 from mouse input</param>
    public void OnLook(InputAction.CallbackContext context)
    {
        if (!allowLookInput) return;

        Vector2 input = context.ReadValue<Vector2>();
        cameraRotation -= input.y * mouseSensitivity / 80;

        cameraRotation = Mathf.Clamp(cameraRotation, -90, 90);

        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0, 0);

        transform.Rotate(Vector3.up * input.x * mouseSensitivity / 80);
    }
}
