using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    bool isGrounded;
    public LayerMask groundMask;
    public Transform groundCheck;
    float groundDistance = 0.4f;

    Vector3 velocity;

    [Header("values")] public float speed = 10f;
    public float jumpHeight = 2f;

// Declare a local variable to store the gravity value
    private float gravity = -9.81f;

// Declare a local variable to store the left shift key state
    private bool leftShiftKeyDown;

    void Start()
    {
        // There is no need to include any code in the Start method
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        // Update the left shift key state
        leftShiftKeyDown = Input.GetKey("left shift");

        // Use the local variable to check the left shift key state and if the player is grounded
        if (leftShiftKeyDown && isGrounded)
        {
            speed = 20f;
        }
        else
        {
            speed = 12f;
        }

        velocity.y += gravity * Time.deltaTime;

        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(velocity * Time.deltaTime);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}