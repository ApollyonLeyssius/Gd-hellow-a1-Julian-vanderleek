using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Gevoeligheid van de muis
    public Transform playerBody; // De speler die de camera moet volgen
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Vergrendel de cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Beweeg de camera omhoog/omlaag
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Beperk op/neer kijken

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Draai de speler links/rechts
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
