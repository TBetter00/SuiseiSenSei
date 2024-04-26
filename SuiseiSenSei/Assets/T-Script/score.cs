using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HSText;
    private void Update()
    {
        ScoreText.text = gameManager.score.ToString();
        if(gameManager.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", gameManager.score);
            HSText.text = gameManager.score.ToString();
        }
        else
        {
            HSText.text = PlayerPrefs.GetInt("HighScore" , 0).ToString();
        }
        
    }
}
