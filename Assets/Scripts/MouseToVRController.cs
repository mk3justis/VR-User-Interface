using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPointer : MonoBehaviour
{
    public InputActionReference horizontalLook;
    public InputActionReference verticalLook;
    public float lookSpeed = 1f;
    public Transform controllerTransform;
    public Camera mainCamera;  // Camera used to convert mouse position
    float pitch;
    float yaw;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        horizontalLook.action.performed += HandleHorizontalLookChange;
        verticalLook.action.performed += HandleVerticalLookChange;
    }

    void Update()
    {
        // Get the mouse position using the Input System
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Convert mouse position to world space
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        // Draw the ray in the Scene view for visualization
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);  // Length of 10 units, change as needed

        // Cast the ray to find the point where the mouse is pointing
        if (Physics.Raycast(ray, out hit))
        {
            // Get the direction from the controller to the hit point
            Vector3 direction = hit.point - controllerTransform.position;

            // Rotate the controller to face the hit point (world space)
            controllerTransform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void HandleHorizontalLookChange(InputAction.CallbackContext obj)
    {
        yaw += obj.ReadValue<float>();
        controllerTransform.localRotation = Quaternion.AngleAxis(yaw * lookSpeed, Vector3.up);
    }

    void HandleVerticalLookChange(InputAction.CallbackContext obj)
    {
        pitch -= obj.ReadValue<float>();
        controllerTransform.localRotation = Quaternion.AngleAxis(pitch * lookSpeed, Vector3.right);
    }
}
