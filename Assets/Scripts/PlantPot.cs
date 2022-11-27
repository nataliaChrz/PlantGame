using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot : MonoBehaviour
{
    public GameObject sprout;
    private GameObject nearTo = null;

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

                Debug.Log(planted);
            }
            nearTo = null;
        }

        //Watering plant function
        if(nearTo != null && Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Key Press");

            if(planted == true)
            {
                water += 1;
                Debug.Log("Plant has been watered " + water);
            }
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearTo = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearTo = null;
        }
    }

}
