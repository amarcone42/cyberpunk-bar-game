using System;
using UnityEngine;

public class AudioSourceLoop : MonoBehaviour
{
    AudioSource m_AudioSource;

    private Boolean status;

    void Start()
    {
        //Fetch the AudioSource component of the GameObject
        m_AudioSource = GetComponent<AudioSource>();
        //Stop the Audio playing
        m_AudioSource.Stop();
        status = false;
    }

    void Update()
    {
        //Turn the loop on and off depending on the status
        m_AudioSource.loop = status;
    }

    public void PlayMusic()
    {
        status = true;
        m_AudioSource.Play();
    }
    public void PlayPauseMusic()
    {
        status = !status;
    }
    public void StopMusic()
    {
        m_AudioSource.Stop();
    }
}
