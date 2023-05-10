using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private ParticleSystem snowToShrinkEFCT;

    [SerializeField]
    private ParticleSystem beenBoostedEFCT;

    [SerializeField]
    private ParticleSystem fenceBeingDeEFCT;

    [SerializeField]
    private float getBigger = 0.25f;
    //[SerializeField]

    private Rigidbody rb;

    public bool isSlowedDown = false;
    private float slowDuration = 3.0f;

    [SerializeField]
    private float slowSpeed = 0.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.transform.localScale = new Vector3(getBigger, getBigger, getBigger);

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (isSlowedDown)
        {

            if (slowDuration >= 0.0f)
            {
                rb.AddForce(movement * slowSpeed);
                slowDuration -= Time.deltaTime;
            }
            else if (slowDuration <= 0.000000f)
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
    }

    


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


    public void HasBeenBoosted()
    {
        gameObject.transform.localScale = new Vector3(getBigger / 4, getBigger / 4, getBigger / 4);
        getBigger = 1f;

        //beenBoostedEFCT.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z);
        beenBoostedEFCT.Play();


    }

    public void hasFenceBeenDestroyed()
    {


        fenceBeingDeEFCT.Play();

    }
}