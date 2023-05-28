using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformOutline : MonoBehaviour
{
    private MeshRenderer platformRenderer;

    private void Start()
    {
        platformRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            // Enable the MeshRenderer when the player enters the trigger
            platformRenderer.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            platformRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            platformRenderer.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            // Enable the MeshRenderer when the player enters the trigger
            platformRenderer.enabled = true;
        }
    }
}
