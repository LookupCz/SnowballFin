using UnityEngine;

public class Achievements : MonoBehaviour
{
    public int destroyedFences;
    public int boostersPickedUp;

    // Singleton instance
    private static Achievements instance;

    // Get the instance of the DataHolder
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
                    singletonObject.name = "DataHolder (Singleton)";
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
}