using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Seed : MonoBehaviour
{
    public static int seedCount;
    public GameObject seedObj;
    public GameObject wholeSeed;
    public GameObject seedParticle;

    public GameObject textPick;

    private AudioSource pickS;

    private GameObject nearTo = null;

    public GameObject animArrow;

    //Make an object with text "Press P to pick up"
    //public GameObject seedText;

    public void Start()
    {
        seedObj.SetActive(true);
        pickS = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (nearTo != null && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Key Press");


            seedParticle.SetActive(true);
            
                pickS.Play();
                seedObj.SetActive(false);
                seedCount += 11;
                textPick.SetActive(false);
            animArrow.SetActive(false);

                Debug.Log("Seed has been picked up " + seedCount);
            
            nearTo = null;
        }

        if(Bed.sleepDays >= 1 && seedCount >= 1)
        {
            seedCount = 0;
            Debug.Log(seedCount);
            seedObj.SetActive(false);
            textPick.SetActive(false);
        }

        if(Bed.sleepDays >= 1 && seedCount == 0)
        {
            wholeSeed.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && seedCount == 0)
        {

            textPick.SetActive(true);
            nearTo = other.gameObject;
        }
        
    }


    public void OnTriggerExit(Collider other)
    {
        textPick.SetActive(false);
        nearTo = null;
    }
}
