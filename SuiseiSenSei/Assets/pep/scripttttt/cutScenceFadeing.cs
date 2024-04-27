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

    private void Start()
    {
        StartFadeTransition();
    }

    public void StartFadeTransition()
    {
        if (!isFading)
        {
            StartCoroutine(FadeTransition());
        }
    }

    IEnumerator FadeTransition()
    {
        yield return new WaitForSeconds(10);
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
