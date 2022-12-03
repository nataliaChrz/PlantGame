using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot4 : MonoBehaviour
{
    public GameObject sprout;
    public GameObject textPlant;
    public GameObject waterText;
    private GameObject nearTo = null;
    private GameObject nearTo2 = null;

    public GameObject growth1;
    public GameObject growth2;
    public GameObject growth3;
    public GameObject growth4;
    public GameObject growth5;

    public GameObject deadPlant;

    public GameObject plantParticle;

    public bool isDead;


    public bool planted = false;

    public static int water;

    public void Start()
    {
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
                water += 1;
                Debug.Log("Plant has been watered " + water);
                waterText.SetActive(false);
            }
            nearTo2 = null;
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
    }

    public void Growth()
    {
        if (Bed.sleepDays == 1)
        {
            if (water == 1)
            {
                sprout.SetActive(false);
                growth1.SetActive(true);

            }
        }
        if (Bed.sleepDays == 2)
        {
            if (water == 2)
            {
                growth1.SetActive(false);
                growth2.SetActive(true);
            }
        }
        if (Bed.sleepDays == 3)
        {
            if (water == 3)
            {
                growth2.SetActive(false);
                growth3.SetActive(true);
            }
        }
        if (Bed.sleepDays == 4)
        {
            if (water == 4)
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
        if (Bed.sleepDays == 5)
        {
            if (water == 5 && isDead == false)
            {
                growth4.SetActive(false);
                growth5.SetActive(true);
            }
        }
    }
}