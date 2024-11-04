using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pogingdrie : MonoBehaviour
{

    public float speed = 5f;
    public Transform cameraTransform;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Use the main camera by default
        }
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Get input from the player (WASD or Arrow Keys)
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow

        // Calculate the direction relative to the camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // We only want the forward and right movement on the X/Z plane (ignore the Y axis)
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Move the player based on camera's forward and right vectors
        Vector3 moveDirection = (forward * vertical + right * horizontal);

        // If there is no input, the moveDirection should be zero
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // Apply movement using the CharacterController
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}