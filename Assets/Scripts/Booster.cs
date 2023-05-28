using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField]
    private float explosionForce = 5f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            //Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            //Vector3 forceDirection = playerMovement.transform.forward;

            playerMovement.HasBeenBoosted(1f, 5f);

            //playerRigidbody.AddExplosionForce(explosionForce, forceDirection,0f ,2f, ForceMode.Impulse);

            Achievements.Instance.IncrementBoostersPickedUp();
            //playerMovement.HasBeenBoosted();

            Destroy(gameObject);
        }
    }
}
