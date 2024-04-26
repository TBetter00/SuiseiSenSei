using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AlphaChanger : MonoBehaviour
{
    public Image img;
    public float fadeDuration = 1f;
    private bool isChanging = false;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeAlphaAndLoadScene);
    }

    void ChangeAlphaAndLoadScene()
    {
        if (!isChanging)
        {
            img.gameObject.SetActive(true);

            isChanging = true;
            StartCoroutine(ChangeAlphaOverTimeAndLoadScene());
        }
    }

    IEnumerator ChangeAlphaOverTimeAndLoadScene()
    {
        float elapsedTime = 0f;
        Color imgColor = img.color;
        float startAlpha = imgColor.a;
        float targetAlpha = 1f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            imgColor.a = alpha;
            img.color = imgColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imgColor.a = targetAlpha;
        img.color = imgColor;

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(1);

        yield return new WaitForSeconds(1f);

        img.gameObject.SetActive(false);
        imgColor.a = 0f;
        img.color = imgColor;

        isChanging = false;
    }
}
