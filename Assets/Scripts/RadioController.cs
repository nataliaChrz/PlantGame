
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class RadioController : MonoBehaviour
{
    [Header("List of Tracks")]
    [SerializeField] private Track[] audioTracks;
    private int trackIndex;

    [Header("Text UI")]
    [SerializeField] private TMP_Text trackTextUI;

    private AudioSource radioAudioSource;

    public GameObject uiRadio;
    public ParticleSystem radioParticle;

    private void Start() 
    {
        radioAudioSource = GetComponent<AudioSource>();

        trackIndex = 0;

        radioAudioSource.clip = audioTracks[trackIndex].trackAudioClip;
       
        trackTextUI.text = audioTracks[trackIndex].name;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiRadio.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        uiRadio.SetActive(false);
    }

    public void SkipForwardButton()
    {
        if (trackIndex < audioTracks.Length - 1)
        {

            radioParticle.Clear();
            trackIndex++;
            UpdateTrack(trackIndex);
            radioParticle.Pause();

        }
    }

    public void SkipBackwardsButton()
    {
        if (trackIndex >= 1)
        {
            radioParticle.Clear();
            trackIndex--;
            UpdateTrack(trackIndex);
            
            radioParticle.Pause();
        }
    }

    void UpdateTrack(int index)
    {
        radioAudioSource.clip = audioTracks[index].trackAudioClip;
        trackTextUI.text = audioTracks[index].name;
        
    }
    
    public void AudioVolume(float volume)
    {
        radioAudioSource.volume = volume;
    }

    public void PlayAudio()
    {
        radioAudioSource.Play();
        radioParticle.Play();
    }
    
    public void PauseAudio()
    {
        radioAudioSource.Pause();
        
        radioParticle.Pause();
    }

    public void StopAudio()
    {
        radioAudioSource.Stop();
        radioParticle.Clear();
        radioParticle.Pause();
    }
}