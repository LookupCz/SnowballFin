using System;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    private TextMeshProUGUI text;
    private PlayerMovement player;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        player = FindPlayerMovement();
    }

    private PlayerMovement FindPlayerMovement()
    {
        // Find the Snow parent object
        GameObject snowParent = GameObject.Find("PlayerLASTwCam/Snow");
        if (snowParent != null)
        {
            // Find the snowmanBody object under the Snow parent
            Transform snowmanBody = snowParent.transform.Find("snowmanBody");
            if (snowmanBody != null)
            {
                // Find the PlayerMovement component on the snowmanBody or its parent
                PlayerMovement playerMovement = snowmanBody.GetComponent<PlayerMovement>();
                if (playerMovement == null)
                {
                    playerMovement = snowmanBody.GetComponentInParent<PlayerMovement>();
                }
                return playerMovement;
            }
        }

        return null;
    }

    private void Update()
    {
        if (player != null)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(player.MoveTimer);
            string timerText = string.Format("{0:00}:{1:00}:{2:0000}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            text.text = timerText;
        }
    }
}
