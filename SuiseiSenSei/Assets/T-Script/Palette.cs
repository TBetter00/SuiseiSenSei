using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    public GameManager GameManager;
    public int powerget;
    public GameObject pellet;
    public float DAYS;
    public float DAYS2;
    [HideInInspector]public bool isEaten = false;
    public bool isPowerUp1;
    public GameObject PowerUp1;
    [HideInInspector]public bool CoolDown = false;
    public PowerCheck powerCheck;
    public GameObject PowerUp2;
    public bool IsPowerUp2;

    private void Awake(){
        powerCheck = FindObjectOfType<PowerCheck>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pacmon") && !isPowerUp1  && !IsPowerUp2 && !isEaten)
        {
            GameManager.PelletEat(10);
            isEaten = true;
        }else if(collision.gameObject.CompareTag("pacmon") && isPowerUp1 && !isEaten)
        {
            isEaten = true;
            powerCheck.AddPower();
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
        }else if(IsPowerUp2 == true)
        {
            pellet.SetActive(false);
            if (!isEaten)
            {
                PowerUp2.SetActive(true);
                StartCoroutine(DeactivatePowerUp2(DAYS2));
            }
            else if (isEaten)
            {
                PowerUp2.SetActive(false);
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
    IEnumerator DeactivatePowerUp2(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsPowerUp2 = false;
        Debug.Log("Deactivated 2");
        PowerUp2.SetActive(false);
    }
}
