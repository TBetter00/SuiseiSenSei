using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletRoller2 : MonoBehaviour
{
    public Palette[] pellet;
    public int PowerUp2num;
    public Pacmon pacmon;
    public PelletRoller pelletRoller;

    private bool needsShuffle = true; // Flag to indicate whether shuffling is needed

    private void Start()
    {
        pellet = FindObjectsOfType<Palette>();
    }

    private void Update()
    {
        if (!FindAnyPowerUp2())
        {
            needsShuffle = true;
        }
        if (needsShuffle)
        {
            if (pacmon.stage3)
            {
                Shuffle();
                needsShuffle = false; // Set the flag to false after shuffling
            }
        }
    }

    private void Shuffle()
    {
        for (int i = pellet.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            // Find a random index that doesn't have PowerUp1
            while (randomIndex == pelletRoller.randomIndex)
            {
                randomIndex = Random.Range(0, i + 1);
            }

            Palette temp = pellet[i];
            pellet[i] = pellet[randomIndex];
            pellet[randomIndex] = temp;
        }

        // Assign power-ups to random pellets based on PowerUpnum
        for (int i = 0; i < Mathf.Min(PowerUp2num, pellet.Length); i++)
        {
            pellet[i].IsPowerUp2 = true;
        }

        // Debug.Log("Shuffling complete");
    }

    private bool FindAnyPowerUp2()
    {
        foreach (Palette p in pellet)
        {
            if (p.IsPowerUp2 && !p.isEaten)
            {
                return true;
            }
        }
        return false;
    }
}