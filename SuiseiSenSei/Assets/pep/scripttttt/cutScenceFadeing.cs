using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class cutScenceFadeing : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;
    private float timer;
    private bool isFading = false;
    private bool codeEnabled = true;

    private void Start()
    {
        StartCoroutine(StartFadeTransition());
        StartCoroutine(DisableForOneSecond());
    }

    private IEnumerator DisableForOneSecond()
    {
        codeEnabled = false;
        yield return new WaitForSeconds(1f);
        codeEnabled = true;
    }

    IEnumerator StartFadeTransition()
    {
        if (!isFading)
        {
            yield return new WaitForSeconds(10);
            codeEnabled = false;
            StartCoroutine(FadeTransition());
        }
    }

    private void Update()
    {
       if (Input.anyKeyDown && codeEnabled)
        {
            codeEnabled = false;
            StartCoroutine(FadeTransition());
        }
    }

    IEnumerator FadeTransition()
    {
        if(!codeEnabled)
        {
            fadePanel.gameObject.SetActive(true);
            isFading = true;
            float startTime = Time.time;
            Color startColor = fadePanel.color;
            Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1);

            while (Time.time < startTime + fadeDuration)
            {
                float t = (Time.time - startTime) / fadeDuration;
                fadePanel.color = Color.Lerp(startColor, endColor, t);
                yield return null;
            }

            SceneManager.LoadScene(3);

            while (fadePanel.color.a > 0)
            {
                fadePanel.color -= new Color(0, 0, 0, Time.deltaTime / fadeDuration);
                yield return null;
            }

            isFading = false;
        }
    }
}
