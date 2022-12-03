using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Seed : MonoBehaviour
{
    public static int seedCount;
    public GameObject seedObj;
    public GameObject textPick;

    private AudioSource pickS;

    //Make an object with text "Press P to pick up"
    //public GameObject seedText;

    public void Start()
    {
        seedObj.SetActive(true);
        pickS = GetComponent<AudioSource>();
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textPick.SetActive(true);
            
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.P))
        {
            pickS.Play();
            seedObj.SetActive(false);
            seedCount += 1;
            textPick.SetActive(false);
            
            Debug.Log("Seed has been picked up " + seedCount);
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        textPick.SetActive(false);
    }
}
