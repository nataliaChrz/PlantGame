using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PetCat : MonoBehaviour
{
    public GameObject catText;
    public ParticleSystem catParticle;

    private AudioSource catMeow;

    public void Start()
    {
        catMeow = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            catText.SetActive(true);

        }
       
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.C))
        {
            catMeow.Play();
            catParticle.Play();

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            catText.SetActive(false);
        }
    }
}
