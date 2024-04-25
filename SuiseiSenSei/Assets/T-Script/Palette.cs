using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    public GameManager GameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pacmon"))
        {
            GameManager.PelletEat(10);
            this.gameObject.SetActive(false);
        }
    }
}
