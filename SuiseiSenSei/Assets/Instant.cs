using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant : MonoBehaviour
{
    public GameObject testParticle;
    public GameObject testParticle2;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(testParticle, this.gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(testParticle2, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
