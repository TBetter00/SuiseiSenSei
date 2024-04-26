using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    public GameManager GameManager;
    private Skill skill;
    public GameObject pellet;
    public float DAYS;
    [HideInInspector]public bool isEaten = false;
    public bool isPowerUp1;
    public GameObject PowerUp1;
    [HideInInspector]public bool CoolDown = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pacmon") && !isPowerUp1 && !isEaten)
        {
            GameManager.PelletEat(10);
            isEaten = true;
        }else if(collision.gameObject.CompareTag("pacmon") && isPowerUp1 && !isEaten)
        {
            isEaten = true;
            skill.Power ++;
        }
    }
    private void Update()
    {
        if(isPowerUp1 == true)
        {
            pellet.SetActive(false);
            if (!isEaten)
            {
                PowerUp1.SetActive(true);
                StartCoroutine(DeactivatePowerUp(DAYS));
            }
            else if(isEaten)
            {
                PowerUp1.SetActive(false);
            }
            
        }else if(isPowerUp1 == false)
        {   
            if (!isEaten)
            {   
                pellet.SetActive(true);
            }
            if (isEaten)
            {
                pellet.SetActive(false);
            }
        }
    }
    IEnumerator DeactivatePowerUp(float delay)
    {
        yield return new WaitForSeconds(delay);
        isPowerUp1 = false;
        Debug.Log("Deactivated");
        PowerUp1.SetActive(false);
    }
}
