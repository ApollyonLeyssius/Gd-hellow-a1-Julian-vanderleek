using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Normale loopsnelheid
    public float sprintSpeed = 10f; // Sprint snelheid
    public float jumpForce = 5f; // Kracht voor springen
    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Animator ophalen
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        // Beweging via toetsenbord (WASD / pijltjestoetsen)
        float moveX = Input.GetAxis("Horizontal"); // Links/rechts (A/D of pijltjestoetsen)
        float moveZ = Input.GetAxis("Vertical");   // Vooruit/achteruit (W/S of pijltjestoetsen)

        // Bepaal de snelheid op basis van de sprinttoets
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        // Beweeg de speler
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * currentSpeed * Time.deltaTime);

        // Set de animaties afhankelijk van de beweging
        if (animator != null)
        {
            bool isMoving = moveX != 0 || moveZ != 0;
            animator.SetBool("isMoving", isMoving); // Zet animatie voor bewegen
            animator.SetFloat("Speed", isMoving ? currentSpeed : 0); // Zet snelheid voor animatie

            // Zet de animatie voor springen
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}