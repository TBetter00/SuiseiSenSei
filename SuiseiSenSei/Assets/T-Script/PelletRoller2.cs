using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletRoller2 : MonoBehaviour
{
    public Palette[] pellet;
    public int PowerUp2num;
    public Pacmon pacmon;

    private void Start()
    {
        pellet = FindObjectsOfType<Palette>();
    }

    private void Update()
    {
        Debug.Log("FindAnyPowerUp :" + FindAnyPowerUp());
        if (!FindAnyPowerUp())
        {
            //Debug.Log("Shuffling");
            if (!pacmon.stageEgg)
            {
                Shuffle();
            }
        }
    }

    public void Shuffle()
    {
        // Shuffle the array using Fisher-Yates shuffle algorithm
        for (int i = pellet.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Palette temp = pellet[i];
            pellet[i] = pellet[randomIndex];
            pellet[randomIndex] = temp;
        }

        // Assign power-ups to random pellets based on PowerUpnum
        for (int i = 0; i < Mathf.Min(PowerUp2num, pellet.Length); i++)
        {
            pellet[i].IsPowerUp2 = true;
        }

        Debug.Log("Shuffling complete");
    }

    public bool FindAnyPowerUp()
    {
        for (int i = 0; i < pellet.Length; i++)
        {
            if (pellet[i].IsPowerUp2 && !pellet[i].isEaten)
            {
                return true;
            }
        }
        return false;
    }
}