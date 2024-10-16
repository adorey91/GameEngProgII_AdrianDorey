using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class InputManager : MonoBehaviour
{
    // Script References
    [SerializeField] private PlayerLocomotionHandler playerLocomotionHandler;
    [SerializeField] private CameraManager cameraManager; // Reference to CameraManager


    [Header("Movement Inputs")]
    public float verticalInput;
    public float horizontalInput;
    public bool jumpInput;
    public Vector2 movementInput;
    public float moveAmount;

    [Header("Camera Inputs")]
    public float scrollInput; // Scroll input for camera zoom
    public Vector2 cameraInput; // Mouse input for the camera

    public bool isPauseKeyPressed = false;

    public Camera playerCamera;
    public LayerMask cubeFilter;
    public LayerMask groundFilter;
    public float distance = 10;

    public Renderer targetRenderer;


    //public void HandleAllInputs()
    //{
    //    HandleMovementInput();
    //    HandleJumpInput();
    //    HandleCameraInput();
    //    HandlePauseKeyInput();
    //}

    public void Look(InputAction.CallbackContext context)
    {

        // Get mouse input for the camera
        //cameraInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cameraInput = context.ReadValue<Vector2>();

        // Get scroll input for camera zoom
        scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Send inputs to CameraManager
        cameraManager.zoomInput = scrollInput;
        cameraManager.cameraInput = cameraInput;
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        //movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
            isPauseKeyPressed = true;
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
            playerLocomotionHandler.isSprinting = true;
        if (context.canceled)
            playerLocomotionHandler.isSprinting = false;
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            playerLocomotionHandler.HandleJump(); // Trigger jump in locomotion handler
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;

            // // origin -> direction -> output variable -> max distance
            // if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10, cubeFilter.value))
            // {
            //     if (hit.collider.TryGetComponent(out Renderer renderer))
            //     {
            //         if (renderer.material.color == Color.blue)
            //             renderer.material.color = Color.red;
            //         else
            //             renderer.material.color = Color.blue;
            //     }
            // }

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 15, groundFilter.value))
            {
                distance = hit.distance;
            }

            RaycastHit[] hits = Physics.RaycastAll(playerCamera.transform.position, playerCamera.transform.forward, distance, cubeFilter.value);
            foreach (RaycastHit hit2 in hits)
            {
                if (hit2.collider.TryGetComponent(out Renderer renderer))
                {
                    targetRenderer = renderer;
                        targetRenderer.material.color = Color.red;
                }
            }
        }
    }

    public void FixedUpdate()
    {
        RaycastHit hit;

        if (!Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 15, cubeFilter.value))
        {
            targetRenderer.material.color = Color.blue;
        }
    }
}
