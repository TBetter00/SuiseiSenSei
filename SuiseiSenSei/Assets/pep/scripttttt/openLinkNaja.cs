using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;


public class openLinkNaja : MonoBehaviour
{
    public string link;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Openlink);
    }

    public void Openlink()
    {
        Process.Start(link);
    }
}