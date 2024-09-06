using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    // Movement speed variables
    public float moveSpeed = 10f;

    // Moon gravity value (1/6th of Earth's gravity)
    public float moonGravity = -1.62f;

    // Rigidbody component for the spaceship
    private Rigidbody rb;

    void Start()
    {
        // Initialize Rigidbody and apply moon-like gravity
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, moonGravity, 0);
    }

    void Update()
    {
        // Movement input (Space/S for forward/backward, A/D for left/right, Q/E for up/down)
        float moveForward = 0f;

        // Move forward when pressing Space, move backward with S
        if (Input.GetKey(KeyCode.Space)) 
        {
            moveForward = moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S)) // Move backward
        {
            moveForward = -moveSpeed * Time.deltaTime;
        }

        // Lateral movement (A/D for left/right)
        float moveRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // A/D or Left/Right Arrow

        // Vertical movement (Q/E for up/down)
        float moveUpDown = 0f;
        if (Input.GetKey(KeyCode.Q)) // Move down
        {
            moveUpDown = -moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E)) // Move up
        {
            moveUpDown = moveSpeed * Time.deltaTime;
        }

        // Apply movement to the spaceship
        Vector3 moveDirection = transform.forward * moveForward + transform.right * moveRight + transform.up * moveUpDown;
        transform.position += moveDirection;
    }
}
