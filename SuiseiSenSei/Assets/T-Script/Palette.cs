using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    public GameManager GameManager;
    public bool isPowerUp1;
    public GameObject PowerUp1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pacmon") && !isPowerUp1)
        {
            GameManager.PelletEat(10);
            Color objectColor = GetComponent<SpriteRenderer>().color;
            objectColor.a = 0f;
            GetComponent<SpriteRenderer>().color = objectColor;
        }
    }
    private void Update()
    {
        if(isPowerUp1 == true)
        {
            PowerUp1.SetActive(true);
        }
    }
}
