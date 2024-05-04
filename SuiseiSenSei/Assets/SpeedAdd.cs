using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdd : MonoBehaviour
{
    public Movement movement;
    public Pacmon pacmon;
    public float addspeed;
    private void Start()
    {
        pacmon = FindObjectOfType<Pacmon>();
    }
    private void Update()
    {
        if (pacmon.stageMega)
        {
            movement.speedMultiplier = addspeed;
        }
        else
        {
            movement.speedMultiplier = 0.1f;
        }
    }
}
