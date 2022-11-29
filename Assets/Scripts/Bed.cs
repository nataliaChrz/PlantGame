using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private GameObject nearTo = null;

    public GameObject bedText;
    public GameObject sleep;


    public GameObject p1Sprout;
    public GameObject  p1Growth1;

    public static int sleepDays;
    
    void Start()
    {
        sleepDays = 0;
        p1Growth1.SetActive(false);
    }

    
    private void Update()
    {
        if (nearTo != null && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Key Press");

            StartCoroutine(SleepCorountine());

            sleepDays += 1;

           

            Debug.Log("Day" + sleepDays);
            nearTo = null;
        }

        Days();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearTo = other.gameObject;
            bedText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bedText.SetActive(false);
            nearTo = null;
        }
    }

    public void Water()
    {
        if(PlantPot.water == 2)
        {
            //Plant grows
            p1Growth1.SetActive(true);
            p1Sprout.SetActive(false);
            

        }
    }

    public void Days()
    {
        if (sleepDays == 1)
        {
            Water();
        }
        if (sleepDays == 2)
        {

        }
        if (sleepDays == 3)
        {

        }
        if (sleepDays == 4)
        {

        }
        if (sleepDays == 5)
        {

        }
        if(sleepDays == 6)
        {

        }
    }

    IEnumerator SleepCorountine(){
         sleep.SetActive(true);
         yield return new WaitForSeconds(3);
         sleep.SetActive(false);

    }
}
