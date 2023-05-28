using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SnowmanInstaFinish : MonoBehaviour
{
    private TMP_Text tmpText;
    private PlayerMovement playerMovement;

    [SerializeField]
    private string nextLevelName;

    private bool canContinue = false;

    private void Start()
    {
        tmpText = GetComponentInChildren<TMP_Text>();

        tmpText.text = "Too far away to continue";
    }

    private void Update()
    {
        if (canContinue)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Achievements dataHolder = Achievements.Instance;
                dataHolder.SetTime(SceneManager.GetActiveScene().name, playerMovement.MoveTimer);
                SceneManager.LoadScene(nextLevelName);
                if (nextLevelName == "LevelMenu")
                {
                    UnityEngine.Cursor.lockState = CursorLockMode.None;
                    UnityEngine.Cursor.visible = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            if (Vector3.Distance(playerMovement.transform.position, gameObject.transform.position) <= 2f)
            {

                if (playerMovement.transform.localScale.x <= 1f && playerMovement.transform.localScale.x >= 0.6f)
                {
                    tmpText.text = "Press E to get into next Level";
                    canContinue = true;
                }
                else
                {
                    tmpText.text = "You are either too big or small";
                    canContinue = false;
                }
            }
            else
            {
                tmpText.text = "Too far away to continue";
                canContinue = false;
            }
        }
    }

    public void StartedToMove()
    {


    }
}
