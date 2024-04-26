using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI HSText;
    private void Start()
    {
        HSText.text = "HIGHSCORE : "+ PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        HSText.text = "HIGHSCORE : 0";
    }
}
