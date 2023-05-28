using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField]
    private float speed = 1.5f;
    private float orSpeed;
    [SerializeField]
    private float getBigger = 0.25f;
    [SerializeField]
    private float jumpForce = 5f;

    public bool isSlowedDown = false;
    private float slowDuration = 3.0f;

    [SerializeField]
    private float slowSpeed = 1f;

    [Header("Particles")]
    [SerializeField]
    private ParticleSystem snowToShrinkEFCT;

    [SerializeField]
    private ParticleSystem beenBoostedEFCT;

    [SerializeField]
    private ParticleSystem fenceBeingDeEFCT;


    private Rigidbody rb;
    private Camera mainCamera;

    [Header("Gameplay")]
    private float timeToSave = 5f;
    [SerializeField]
    private float fellThreshold;
    private bool isPaused = false;


    private Vector3 lastPos;
    private Quaternion lastRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        gameObject.transform.localScale = new Vector3(getBigger, getBigger, getBigger);

        orSpeed = speed;
    }

    private void Update()
    {

        timeToSave -= Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //need to repair this

            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (isSlowedDown)
        {
            if (slowDuration >= 0.0f)
            {
                rb.AddForce(movement * slowSpeed);
                slowDuration -= Time.deltaTime;
            }
            else if (slowDuration <= 0.0f)
            {
                isSlowedDown = false;
            }
        }
        else
        {
            rb.AddForce(movement * speed);
        }

        if (rb.velocity.magnitude > 0.1f)
        {
            getBigger += Time.deltaTime / 4;
            if (gameObject.transform.localScale.x <= 3f)
            {
                gameObject.transform.localScale = new Vector3(getBigger, getBigger, getBigger);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("LevelMenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
        /*if (timeToSave <= 0 && IsGrounded())
        {
            //SavePos();
        }

        if (HasPlayerFell())
        {

            //Respawn();
        }
    }

    private bool HasPlayerFell()
    {
        if (transform.position.y < fellThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
        //....

        //check if he fell then respawn him be careful about timing tho

    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = lastPos;
        gameObject.transform.rotation = lastRot;
    }

    private void SavePos()
    {
        //Debug.Log("ASOJGAOUIBGOABGAOUBGUYAFCVA");

        lastPos = transform.position;
        lastRot = transform.rotation;
        timeToSave = 5f;
    
    } */

    private bool IsGrounded()
    {
        float raycastDistance = 1f;
        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position, -transform.up), out hit, raycastDistance))
        {
            // Check if the hit object is the floor or any other designated tag
            if (hit.collider.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }
    //works
    private void OnCollisionEnter(Collision collision)
    {

        TreeAnim treeAnim = collision.gameObject.GetComponent<TreeAnim>();
        if (treeAnim != null)
        {
            gameObject.transform.localScale = new Vector3(getBigger / 4, getBigger / 4, getBigger / 4);
            getBigger = 0.25f;
            slowDuration = 3.0f;

            snowToShrinkEFCT.transform.position = gameObject.transform.position;
            snowToShrinkEFCT.Play();

        }
    }


    public void HasBeenBoosted(float boostDuration, float boostSpeedMultiplier)
    {
        StartCoroutine(ApplyBoost(boostDuration, boostSpeedMultiplier));

        gameObject.transform.localScale = new Vector3(getBigger / 4, getBigger / 4, getBigger / 4);
        getBigger = 1f;

        //beenBoostedEFCT.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z);
        beenBoostedEFCT.Play();
    }

    private IEnumerator ApplyBoost(float boostDuration, float boostSpeedMultiplier)
    {

        // Multiply the speed by the boost multiplier
        speed *= boostSpeedMultiplier;

        // Wait for the boost duration
        yield return new WaitForSeconds(boostDuration);

        // Restore the original speed
        speed = orSpeed;
    }

    public void hasFenceBeenDestroyed()
    {


        fenceBeingDeEFCT.Play();

    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}