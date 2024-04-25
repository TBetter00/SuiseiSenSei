using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI ScoreText;
    private void Update()
    {
        ScoreText.text = gameManager.score.ToString();
    }
}
