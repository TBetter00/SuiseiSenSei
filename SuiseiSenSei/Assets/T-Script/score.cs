using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public float Score;
    public TextMeshProUGUI ScoreText;
    private void Update()
    {
        ScoreText.text = Score.ToString();
    }
}
