using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant : MonoBehaviour
{
    public GameObject testParticle;
    public GameObject testParticle2;
    public GameObject testParticle3;
    public GameObject testParticle4;
    public GameObject testParticle5;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(testParticle, this.gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(testParticle2, this.gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(testParticle3, this.gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(testParticle4, this.gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Instantiate(testParticle5, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
