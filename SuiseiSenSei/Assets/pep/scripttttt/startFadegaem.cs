using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class startFadegaem : MonoBehaviour
{
    public Image blackImg;
    public float fadeDuration = 1f;

    void Start()
    {
        blackImg.gameObject.SetActive(true);
        SetImageAlpha(blackImg, 1f);

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float startTime = Time.time;

        while (Time.time - startTime < fadeDuration)
        {
            float elapsedTime = Time.time - startTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SetImageAlpha(blackImg, alpha);
            yield return null;
        }

        SetImageAlpha(blackImg, 0f);
        blackImg.gameObject.SetActive(false);
    }

    void SetImageAlpha(Image img, float alpha)
    {
        Color imgColor = img.color;
        imgColor.a = alpha;
        img.color = imgColor;
    }
}
