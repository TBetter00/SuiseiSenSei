using UnityEngine;

public class PlayPause : MonoBehaviour
{
    public GameObject canvas;
    public bool isPaused = false;
    public AudioSource bgmAudioSource;
    public AudioSource bgmAudioSourceMega;

    public bool IsPaused
    {
        get { return isPaused; }
    }

    void Start()
    {
        Time.timeScale = 1;

        if (canvas != null && canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePlayPause();
        }
    }

    public void TogglePlayPause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            if (canvas != null)
            {
                canvas.SetActive(false);
            }
            if (bgmAudioSource != null)
            {
                bgmAudioSource.UnPause();
                bgmAudioSourceMega.UnPause();
            }
        }
        else
        {
            Time.timeScale = 0;
            if (canvas != null)
            {
                canvas.SetActive(true);
            }
            if (bgmAudioSource != null)
            {
                bgmAudioSource.Pause();
                bgmAudioSourceMega.Pause();
            }
        }
        isPaused = !isPaused;
    }
}
