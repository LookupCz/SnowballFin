using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SnowmanInstaFinish : MonoBehaviour
{
    private TMP_Text tmpText;

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
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
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
