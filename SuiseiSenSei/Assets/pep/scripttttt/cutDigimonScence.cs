using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;


public class CutDigimonScence : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        StartCoroutine(DeactivateFireAfterDelay());
    }

    IEnumerator DeactivateFireAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        animator.Play("flipcutdigimonwalk");
    }
}
