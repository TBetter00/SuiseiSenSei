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
    public bool Powerup2Eaten = false;
    /*[SerializeField] private Animator animator1;
    [SerializeField] private GameObject skillpower1;
    [SerializeField] private Animator animator2;
    [SerializeField] private GameObject skillpower2;*/

    [Header("Effects")]
    public GameObject PowerUp1EatenVfx;
    public GameObject PowerUp2EatenVfx;


    private void Awake(){
        powerCheck = FindObjectOfType<PowerCheck>();
        GameManager = FindObjectOfType<GameManager>();
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
            /*skillpower1.SetActive(true);
            animator1.Play("firewook anim");*/
            Instantiate(PowerUp1EatenVfx, this.gameObject.transform.position, Quaternion.identity);
        }
        else if(collision.gameObject.CompareTag("pacmon") && IsPowerUp2 && !isEaten)
        {
            isEaten = true;
            Powerup2Eaten = true;
            /*skillpower2.SetActive(true);
            animator2.Play("1 Magic");*/
            Instantiate(PowerUp2EatenVfx, this.gameObject.transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        if (isPowerUp1)
        {
            pellet.SetActive(false);
            if (!isEaten)
            {
                PowerUp1.SetActive(true);
                StartCoroutine(DeactivatePowerUp(DAYS));
            }
            else
            {
                PowerUp1.SetActive(false);
            }
            return;
        }
        else if (IsPowerUp2)
        {
            pellet.SetActive(false);
            if (!isEaten)
            {
                PowerUp2.SetActive(true);
                StartCoroutine(DeactivatePowerUp2(DAYS2));
            }
            else
            {
                PowerUp2.SetActive(false);
            }
            return;
        }

        // If no power-up is active, show the regular pellet
        if (!isEaten)
        {
            pellet.SetActive(true);
        }
        else
        {
            pellet.SetActive(false);
        }
    }
    IEnumerator DeactivatePowerUp(float delay)
    {
        yield return new WaitForSeconds(delay);
        isPowerUp1 = false;
        // Debug.Log("Deactivated");
        PowerUp1.SetActive(false);
    }
    IEnumerator DeactivatePowerUp2(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsPowerUp2 = false;
        // Debug.Log("Deactivated 2");
        PowerUp2.SetActive(false);
    }
}
