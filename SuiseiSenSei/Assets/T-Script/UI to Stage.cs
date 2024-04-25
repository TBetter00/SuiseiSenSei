using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItoStage : MonoBehaviour
{
    public Pacmon pacmon;
    public GameManager gameManager;
    public Image[] Stage0;
    public Image[] Stage1;
    public Image[] Stage2;
    public Image[] Stage3;
    public Image[] Stage4;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Stage0.Length; i++)
        {
            if(i < gameManager.lives)
            {
                switch (pacmon.GetCurrentStage())
                {
                    case 0:
                        Stage0[i].enabled = true;
                        break;
                    case 1:
                        Stage1[i].enabled = true;
                        break;
                    case 2:
                        Stage2[i].enabled = true;
                        break;
                    case 3:
                        Stage3[i].enabled = true;
                        break;
                    case 4:
                        Stage4[i].enabled = true;
                        break;
                }
            }
            else
            {
                switch (pacmon.GetCurrentStage())
                {
                    case 0:
                        Stage0[i].enabled = false;
                        break;
                    case 1:
                        Stage1[i].enabled = false;
                        break;
                    case 2:
                        Stage2[i].enabled = false;
                        break;
                    case 3:
                        Stage3[i].enabled = false;
                        break;
                    case 4:
                        Stage4[i].enabled = false;
                        break;
                }
            }
        }
    }
}
