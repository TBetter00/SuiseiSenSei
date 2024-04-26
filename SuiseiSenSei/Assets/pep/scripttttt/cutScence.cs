using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using System;


public class CutScene : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public Animator animator;


    void Start()
    {
        fire1.SetActive(false);
        fire2.SetActive(false);
        StartCoroutine(DeactivateFireAfterDelay());
    }

    IEnumerator DeactivateFireAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        animator.Play("flipcutscencewaalking");
        fire1.SetActive(true);
        fire2.SetActive(true);
    }
}
