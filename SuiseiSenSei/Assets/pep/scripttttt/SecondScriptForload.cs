using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondScriptForload : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        /*gameManager = FindObjectOfType<GameManager>();*/

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found");
        }
    }

    public void UpdateLives(int newLives)
    {
        if (gameManager != null)
        {
            gameManager.ChangeLives(newLives);
        }
    }
}