using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource normalBGM;
    public AudioSource megaBGM;

    public void MutenormalAudio()
    {
        normalBGM.mute = true;
    }

    public void UnmutenormalAudio()
    {
        normalBGM.mute = false;
    }

    void ExampleUsage()
    {
        AudioManager audioManager = GetComponent<AudioManager>();

        audioManager.MutenormalAudio();

        audioManager.UnmutenormalAudio();
    }
}
