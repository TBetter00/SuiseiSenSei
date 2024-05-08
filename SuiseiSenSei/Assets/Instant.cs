using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant : MonoBehaviour
{
    public GameObject testParticle;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(testParticle, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
