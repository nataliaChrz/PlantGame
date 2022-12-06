using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlantPot7 : MonoBehaviour
{
    public GameObject sprout;
    public GameObject textPlant;
    public GameObject waterText;
    public GameObject factText;

    public GameObject factPanel;


    private GameObject nearTo = null;
    private GameObject nearTo2 = null;
    private GameObject nearPlantFacts;

    public GameObject growth1;
    public GameObject growth2;
    public GameObject growth3;
    public GameObject growth4;
    public GameObject growth5;

    public GameObject plantParticle;

    public GameObject deadPlant;
    public ParticleSystem waterParticle;

    public bool isDead;
    private bool factsActive = false;


    public bool planted;

    public static int water;
    private AudioSource PlantAudioSource;

    public AudioClip plantingClip;
    public AudioClip wateringClip;
    public AudioClip factClip;

    public GameObject textDead;
    public GameObject textAlive;
    public GameObject textPlanted;
    public void Start()
    {
        PlantAudioSource = GetComponent<AudioSource>();



        sprout.SetActive(false);
        growth1.SetActive(false);
        growth2.SetActive(false);
        growth3.SetActive(false);
        growth4.SetActive(false);
        growth5.SetActive(false);
        deadPlant.SetActive(false);

        plantParticle.SetActive(false);

        isDead = false;
        planted = false;


    }

    private void Update()
    {
        //Plating seed Function
        if (nearTo != null && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Key Press");

            if (Seed.seedCount >= 1)
            {
                PlantAudioSource.PlayOneShot(plantingClip);
                sprout.SetActive(true);
                Seed.seedCount = Seed.seedCount -= 1;
                Debug.Log("Seed has been planted " + Seed.seedCount);

                plantParticle.SetActive(true);
                planted = true;
                textPlant.SetActive(false);
                Debug.Log(planted);
            }
            nearTo = null;
        }

        //Watering plant function
        if (nearTo2 != null && Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Key Press for Water");

            if (planted == true)
            {
                waterParticle.Play();


                PlantAudioSource.PlayOneShot(wateringClip);
                water += 1;
                Debug.Log("Plant has been watered " + water);
                waterText.SetActive(false);
            }
            nearTo2 = null;
        }
        //Show plant fact panel
        if (nearPlantFacts != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Plant Facts Opening");

            if (planted == true)
            {
                factsActive = !factsActive;
                factPanel.SetActive(factsActive);
                PlantAudioSource.PlayOneShot(factClip);
                //Show Plant fact panel
            }

        }


        Growth();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Seed.seedCount >= 1)
        {

            textPlant.SetActive(true);
            nearTo = other.gameObject;
        }
        if (other.CompareTag("Player") && planted == true)
        {
            waterText.SetActive(true);
            textPlant.SetActive(false);
            nearTo2 = other.gameObject;
            factText.SetActive(true);
            nearPlantFacts = other.gameObject;
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && planted == true)
        {
            if (other.CompareTag("Player") && Seed.seedCount >= 1)
            {

                textPlant.SetActive(true);
                nearTo = other.gameObject;
            }
            if (other.CompareTag("Player") && planted == true)
            {
                waterText.SetActive(true);
                textPlant.SetActive(false);
                nearTo2 = other.gameObject;
                factText.SetActive(true);
                nearPlantFacts = other.gameObject;
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && Seed.seedCount >= 1)
        {
            textPlant.SetActive(false);
            waterText.SetActive(false);
            nearTo = null;
            nearTo2 = null;
            nearPlantFacts = null;
        }

        if (other.CompareTag("Player") && planted == true)
        {
            //put panel text here
            factText.SetActive(false);
            factPanel.SetActive(false);
            waterText.SetActive(false);
        }
    }

    public void Growth()
    {
        if (Bed.sleepDays == 1 && planted == true)
        {
            if (water <= 2)
            {
                sprout.SetActive(false);
                growth1.SetActive(true);

            }
        }
        if (Bed.sleepDays == 2 && planted == true)
        {
            if (water <= 2)
            {
                growth1.SetActive(false);
                growth2.SetActive(true);
            }
        }
        if (Bed.sleepDays == 3 && planted == true)
        {
            if (water <= 2)
            {
                growth2.SetActive(false);
                growth3.SetActive(true);
            }
        }
        if (Bed.sleepDays == 4 && planted == true)
        {
            if (water <= 2)
            {
                growth3.SetActive(false);
                growth4.SetActive(true);
            }
            else
            {
                isDead = true;

                deadPlant.SetActive(true);

                growth1.SetActive(false);
                growth2.SetActive(false);
                growth3.SetActive(false);
                growth4.SetActive(false);
            }

        }
        if (Bed.sleepDays == 5 && planted == true)
        {
            if (water <= 2 && isDead == false)
            {
                growth4.SetActive(false);
                growth5.SetActive(true);
            }
        }
        if (Bed.sleepDays == 6)
        {
            if (isDead == true)
            {
                textDead.SetActive(true);
                textAlive.SetActive(false);
                textPlanted.SetActive(false);
            }
            if (isDead == false)
            {
                textAlive.SetActive(true);
                textDead.SetActive(false);
                textPlanted.SetActive(false);
            }
            if (planted == false)
            {
                textAlive.SetActive(false);
                textDead.SetActive(false);
                textPlanted.SetActive(true);
            }
        }
    }
}
