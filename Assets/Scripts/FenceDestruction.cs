using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceDestruction : MonoBehaviour
{
    [SerializeField]
    public GameObject damagedFencePrefab;

    

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            

            // Instantiate the damaged fence at the same position and rotation as the normal fence
            GameObject damagedFence = Instantiate(damagedFencePrefab, transform.position, transform.rotation);
            damagedFence.transform.localScale = gameObject.transform.localScale;
            // Destroy the normal fence

            playerMovement.hasFenceBeenDestroyed();
            Achievements.Instance.IncrementDestroyedFences();
            Destroy(gameObject);

        }
    }
}
