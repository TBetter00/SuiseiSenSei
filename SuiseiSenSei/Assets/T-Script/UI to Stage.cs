using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItoStage : MonoBehaviour
{
    public Pacmon pacmon;
    public GameManager gameManager;
    public Image[] Stage0;
    public GameObject Egg;
    public Image[] Stage1;
    public GameObject First;
    public Image[] Stage2;
    public GameObject Second;
    public Image[] Stage3;
    public GameObject Third;
    public Image[] Stage4;
    public GameObject fourth;

    // Update is called once per frame
    private void Start()
    {
        switch (pacmon.GetCurrentStage())
        {
            case 0:
                Egg.SetActive(true);
                break;
            case 1:
                First.SetActive(true);
                Egg.SetActive(false);
                break;
            case 2:
                Second.SetActive(true);
                First.SetActive(false);
                break;
            case 3:
                Third.SetActive(true);
                Second.SetActive(false);
                break;
            case 4:
                fourth.SetActive(true);
                Third.SetActive(false);
                break;
        }
    }
    void Update()
    {
        switch (pacmon.GetCurrentStage())
        {
            case 0:
                Egg.SetActive(true);
                break;
            case 1:
                First.SetActive(true);
                Egg.SetActive(false);
                break;
            case 2:
                Second.SetActive(true);
                First.SetActive(false);
                break;
            case 3:
                Third.SetActive(true);
                Second.SetActive(false);
                fourth.SetActive(false);
                break;
            case 4:
                fourth.SetActive(true);
                Third.SetActive(false);
                break;
        }
        // Debug.Log("pacmon.GetCurrentStage :" + pacmon.GetCurrentStage());
        // Debug.Log("gameManager.lives :" + gameManager.lives);
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
