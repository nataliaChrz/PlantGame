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

    private GameObject nearTo = null;

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
            

           
            
                pickS.Play();
                seedObj.SetActive(false);
                seedCount += 10;
                textPick.SetActive(false);

                Debug.Log("Seed has been picked up " + seedCount);
            
            nearTo = null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
