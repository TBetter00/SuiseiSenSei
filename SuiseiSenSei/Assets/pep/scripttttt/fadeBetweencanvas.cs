using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class fadeBetweencanvas : MonoBehaviour
{
    public Image blackImg1;
    public Image blackImg2;
    public Canvas canvas1;
    public Canvas canvas2;
    public float fadeDuration = 1f;
    private bool isChanging = false;

    public void ChangeCanvasAndFade()
    {
        if (!isChanging)
        {
            isChanging = true;
            StartCoroutine(FadeBetweenCanvases());
        }
    }

    IEnumerator FadeBetweenCanvases()
    {
        blackImg1.gameObject.SetActive(true);
        blackImg2.gameObject.SetActive(false);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            SetBlackImageAlpha(blackImg1, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetBlackImageAlpha(blackImg1, 1f);

        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);

        blackImg1.gameObject.SetActive(false);
        blackImg2.gameObject.SetActive(true);

        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SetBlackImageAlpha(blackImg2, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetBlackImageAlpha(blackImg2, 0f);
        blackImg2.gameObject.SetActive(false);

        isChanging = false;
    }

    void SetBlackImageAlpha(Image blackImg, float alpha)
    {
        Color imgColor = blackImg.color;
        imgColor.a = alpha;
        blackImg.color = imgColor;
    }
}
