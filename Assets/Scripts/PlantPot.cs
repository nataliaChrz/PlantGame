using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot : MonoBehaviour
{
    public GameObject sprout;
    private GameObject nearTo = null;
    

    public void Start()
    {
        sprout.SetActive(false);

    }

    private void Update()
    {
        if (nearTo != null && Input.GetKeyDown(KeyCode.P))
        {
             Debug.Log("Key Press");

            if (Seed.seedCount >= 1)
            {
                sprout.SetActive(true);
                Seed.seedCount = Seed.seedCount -= 1;
                Debug.Log("Seed has been planted " + Seed.seedCount);
            }
            nearTo = null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearTo = other.gameObject;
        }
    }

    
}
