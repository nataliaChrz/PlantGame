using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot : MonoBehaviour
{
    public GameObject sprout;
    public GameObject textPlant;
    public GameObject waterText;
    private GameObject nearTo = null;
    private GameObject nearTo2 = null;

    

    public bool planted = false;

    public static int water;

    public void Start()
    {
        sprout.SetActive(false);
        
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
                water += 1;
                Debug.Log("Plant has been watered " + water);
                waterText.SetActive(false);
            }
            nearTo2 = null;
        }
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

}
