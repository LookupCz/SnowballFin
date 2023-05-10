using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteAchievements : MonoBehaviour
{
    [SerializeField]
    private TMP_Text achievementsText;

    private void Start()
    {
        // Get the DataHolder instance
        Achievements dataHolder = Achievements.Instance;

        // Update the TMP_Text component with the data
        achievementsText.text = "Destroyed Fences: " + dataHolder.destroyedFences +
            "\nBoosters Picked Up: " + dataHolder.boostersPickedUp;
    }
}
