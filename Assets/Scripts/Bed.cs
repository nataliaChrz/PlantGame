using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private GameObject nearTo = null;

    public GameObject bedText;
    public GameObject sleep;


    

    public static int sleepDays;
    
    void Start()
    {
        sleepDays = 0;
        
    }

    
    private void Update()
    {
        if (nearTo != null && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Key Press");

            StartCoroutine(SleepCorountine());

            sleepDays += 1;
            bedText.SetActive(false);



            Debug.Log("Day" + sleepDays);
            nearTo = null;
        }

     

       
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
            
            

        }
    }


    IEnumerator SleepCorountine(){
         sleep.SetActive(true);
         yield return new WaitForSeconds(3);
         sleep.SetActive(false);

    }
}
