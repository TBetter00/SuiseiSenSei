using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource normalBGM;
    public AudioSource megaBGM;
    public Pacmon pacmon;

    public void MutenormalAudio()
    {
        normalBGM.mute = true;
    }

    public void UnmutenormalAudio()
    {
        normalBGM.mute = false;
    }

    public void MutemegaAudio()
    {
        megaBGM.mute = true;
    }

    public void UnmutemegaAudio()
    {
        megaBGM.mute = false;
    }

    private void Awake()
    {

        pacmon = FindObjectOfType<Pacmon>();

        if (pacmon == null)
        {
            Debug.LogWarning("Pacmon component not found in the scene!");
        }
    }
    void Update()
    {
        if (pacmon.stage3)
        {
            UnmutenormalAudio();
            MutemegaAudio();
        }
        if (pacmon.stageMega)
        {
            UnmutemegaAudio();
            MutenormalAudio();
        }
    }
}
