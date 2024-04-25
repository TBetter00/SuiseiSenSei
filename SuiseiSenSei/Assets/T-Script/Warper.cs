using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warper : MonoBehaviour
{
    public Transform Warpto;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            other.gameObject.transform.position = Warpto.position;
        }
    }
}
