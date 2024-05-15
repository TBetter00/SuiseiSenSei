using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondScriptForload : MonoBehaviour
{
    public Button yourButton; // Assign in inspector
    public string sceneToLoad; // Assign in inspector

    void Start()
    {
        yourButton.onClick.AddListener(() => LoadScene(sceneToLoad));
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}