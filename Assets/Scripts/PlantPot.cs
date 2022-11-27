using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot : MonoBehaviour
{
    public GameObject sprout;

    public void Start()
    {
        sprout.SetActive(false);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //plantText.SetActive(true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.P))
        {
            if (Seed.seedCount >= 1)
            {
                sprout.SetActive(true);
                Seed.seedCount =- 1;
                Debug.Log("Seed has been planted " + Seed.seedCount);
            }

            

        }
    }
}
