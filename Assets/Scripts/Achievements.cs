using UnityEngine;

public class Achievements : MonoBehaviour
{
    public int destroyedFences;
    public int boostersPickedUp;

    public float firstLevelV2;
    public float secondLevelV2;
    public float thirdLevelV2;
    public float fourthLevelV2;
    // Add more float variables for each level as needed

    // Singleton instance
    private static Achievements instance;

    // Get the instance of the Achievements
    public static Achievements Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Achievements>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Achievements>();
                    singletonObject.name = "Achievements (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    // Increment the destroyedFences variable
    public void IncrementDestroyedFences()
    {
        destroyedFences++;
    }

    // Increment the boostersPickedUp variable
    public void IncrementBoostersPickedUp()
    {
        boostersPickedUp++;
    }

    // Set the time for a specific level
    public void SetTime(string levelName, float time)
    {
        switch (levelName)
        {
            case "FirstLevelV2":
                firstLevelV2 = time;
                break;
            case "SecondLevelV2":
                secondLevelV2 = time;
                break;
            case "ThirdLevelV2":
                thirdLevelV2 = time;
                break;
            case "FourthLevelV2":
                fourthLevelV2 = time;
                break;
                // Add cases for other levels as needed
        }
    }

    // Get the time for a specific level
    public float GetTime(string levelName)
    {
        switch (levelName)
        {
            case "FirstLevelV2":
                return firstLevelV2;
            case "SecondLevelV2":
                return secondLevelV2;
            case "ThirdLevelV2":
                return thirdLevelV2;
            case "FourthLevelV2":
                return fourthLevelV2;
                // Add cases for other levels as needed
        }

        return float.MaxValue;
    }
}
