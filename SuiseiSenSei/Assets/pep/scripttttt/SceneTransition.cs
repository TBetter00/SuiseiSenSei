using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneTransition : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;
    private float timer;
    private bool isFading = false;

    public void StartFadeTransition(int sceneIndex)
    {
        if (!isFading)
        {
            StartCoroutine(FadeTransition(sceneIndex));
        }
    }

    IEnumerator FadeTransition(int sceneIndex)
    {
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

        SceneManager.LoadScene(sceneIndex);

        while (fadePanel.color.a > 0)
        {
            fadePanel.color -= new Color(0, 0, 0, Time.deltaTime / fadeDuration);
            yield return null;
        }

        isFading = false;
    }
}
