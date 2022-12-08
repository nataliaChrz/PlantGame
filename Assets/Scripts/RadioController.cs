
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    private AudioSource radioAudioSource;

    private void Start() 
    {
        radioAudioSource = GetComponent<AudioSource>();
    }
    
    public void AudioVolume(float volume)
    {
        radioAudioSource.volume = volume;
    }

    public void PlayAudio()
    {
        radioAudioSource.Play();
    }
    
    public void PauseAudio()
    {
        radioAudioSource.Pause();  
    }

    public void StopAudio()
    {
        radioAudioSource.Stop();
    }
}