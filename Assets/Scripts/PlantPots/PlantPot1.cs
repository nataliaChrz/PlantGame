using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlantPot1 : MonoBehaviour
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
    

    public bool planted = false;

    public static int water;
    private AudioSource Plant;

    public void Start()
    {
        Plant = GetComponent<AudioSource>();
        sprout.SetActive(false);
        growth1.SetActive(false);
        growth2.SetActive(false);
        growth3.SetActive(false);
        growth4.SetActive(false);
        growth5.SetActive(false);
        deadPlant.SetActive(false);

        plantParticle.SetActive(false);

        isDead = false;
        
    }

    private void Update()
    {
        //Plating seed Function
        if (nearTo != null && Input.GetKeyDown(KeyCode.P))
        {
             Debug.Log("Key Press");

            if (Seed.seedCount >= 1)
            {
                Plant.Play();
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
        if(nearTo2 != null && Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Key Press for Water");

            if(planted == true)
            {
                waterParticle.Play();
                water += 1;
                Debug.Log("Plant has been watered " + water);
                waterText.SetActive(false);
            }
            nearTo2 = null;
        }
        //Show plant fact panel
        if(nearPlantFacts != null && Input.GetKeyDown(KeyCode.Mouse0) && planted == true)
        {
            Debug.Log("Plant Facts Opening");

            if(planted == true)
            {
                factPanel.SetActive(true);
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
        if(other.CompareTag("Player") && planted == true){
            waterText.SetActive(true);
            textPlant.SetActive(false);
            nearTo2 = other.gameObject;
            factText.SetActive(true);
            nearPlantFacts = other.gameObject;
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && planted == true)
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
        }

        if(other.CompareTag("Player") && planted == true)
        {
            //put panel text here
            factText.SetActive(false);
            factPanel.SetActive(false);
            waterText.SetActive(false);
        }
    }

    public void Growth(){
        if(Bed.sleepDays == 1){
            if(water == 1){
               sprout.SetActive(false);
               growth1.SetActive(true);

            }
        }
        if(Bed.sleepDays == 2){
            if(water == 2){
                growth2.SetActive(true);
            }
        }
        if(Bed.sleepDays == 3){
            if(water == 3){
                growth3.SetActive(true);
            }
        }
        if(Bed.sleepDays == 4)
        {
            if (water == 4)
            {
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
        if(Bed.sleepDays == 5)
        {
            if(water == 5 && isDead == false)
            {
                growth5.SetActive(true);
            }
        }
    }
}
