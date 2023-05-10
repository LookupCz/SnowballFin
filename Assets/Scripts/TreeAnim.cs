using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnim : MonoBehaviour
{

    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StopShakingAnimation()
    {
        
        yield return new WaitForSeconds(0.44f); // Adjust the duration as needed

        mAnimator.SetBool("CollidedToShake", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (mAnimator != null)
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                mAnimator.SetBool("CollidedToShake", true);
                StartCoroutine(StopShakingAnimation());

                playerMovement.isSlowedDown = true;

            }
        }
    }
}
