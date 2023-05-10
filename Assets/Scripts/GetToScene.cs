using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetToScene : MonoBehaviour
{
    [SerializeField]
    private string sceneToGo;
    private Button mButton;


    private void Start()
    {
        mButton = GetComponent<Button>();

        mButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(sceneToGo);
    }
}
