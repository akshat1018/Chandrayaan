using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLost : MonoBehaviour
{
    // Reference to the object that should be activated
    public GameObject objectToActivate;

    // Reference to the camera that should be deactivated
    public Camera mainCamera;

    // Ensure this is attached to a GameObject with a Rigidbody and Collider with "Is Trigger" checked

    private void OnTriggerEnter(Collider other)
    {
        // Check if the spaceship collided with the trigger
        if (other.CompareTag("Spaceship"))
        {
            // Activate the target GameObject
            objectToActivate.SetActive(true);

            // Deactivate the main camera
            mainCamera.gameObject.SetActive(false);

            Debug.Log("Collision detected: Spaceship triggered object activation and camera deactivation.");
        }
    }
}
