using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletRoller : MonoBehaviour
{
    public Palette[] pellet;
    int randomIndex;
    private void Update()
    {
        pellet = FindObjectsOfType<Palette>();
        if(FindAnyPowerUp() == false)
        {
            Shuffle();
        }
    }
    public void Shuffle()
    {
        for(int i = 0; i<=pellet.Length; i++)
        {
            randomIndex = Random.Range(0,pellet.Length);
            pellet[randomIndex].isPowerUp1 = true;
        }
    }
    public bool FindAnyPowerUp()
    {
        for(int i = 0; i < pellet.Length; i++)
        {
            if (pellet[i].isPowerUp1)
            {
                return true;
            }
        }return false;
    }
}
