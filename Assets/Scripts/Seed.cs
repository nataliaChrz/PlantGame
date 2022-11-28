using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public static int seedCount;
    public GameObject seedObj;
    public GameObject textPick;

    //Make an object with text "Press P to pick up"
    //public GameObject seedText;

    public void Start()
    {
        seedObj.SetActive(true);
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
