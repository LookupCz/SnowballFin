using System;
using UnityEngine;
using TMPro;

public class ShowTimer : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshPro;

    [SerializeField]
    private string ownSceneName;

    private void Start()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Achievements dataHolder = Achievements.Instance;
        float levelTime = dataHolder.GetTime(ownSceneName);
        if (levelTime != float.MaxValue)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(levelTime);
            string timerText = string.Format("{0:00}:{1:00}:{2:0000}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            m_TextMeshPro.text = $"Personal best:\n {timerText}";
        }
    }
}
