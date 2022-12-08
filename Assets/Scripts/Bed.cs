using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private GameObject nearTo = null;

    public GameObject bedText;
    public GameObject sleep1;
    public GameObject sleep2;
    public GameObject sleep3;
    public GameObject sleep4;
    public GameObject sleep5;

    public GameObject sleep6End;

    private AudioSource sleepSound;

    public static int sleepDays;
    
    void Start()
    {
        sleepDays = 0;
        sleepSound = GetComponent<AudioSource>();
        Cursor.visible = true;
    }

    
    private void Update()
    {
        if (nearTo != null && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Key Press");

            sleepSound.Play();
            sleepDays += 1;
            StartCoroutine(SleepCorountine());

           
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


    IEnumerator SleepCorountine(){
        // sleep1.SetActive(true);
        // yield return new WaitForSeconds(3);
         //sleep1.SetActive(false);

        if(sleepDays == 1)
        {
            sleep1.SetActive(true);
            yield return new WaitForSeconds(3);
            sleep1.SetActive(false);
        }
        if(sleepDays == 2)
        {
            sleep2.SetActive(true);
            yield return new WaitForSeconds(3);
            sleep2.SetActive(false);
        }
        if(sleepDays == 3)
        {
            sleep3.SetActive(true);
            yield return new WaitForSeconds(3);
            sleep3.SetActive(false);
        }
        if(sleepDays == 4)
        {
            sleep4.SetActive(true);
            yield return new WaitForSeconds(3);
            sleep4.SetActive(false);
        }
        if(sleepDays == 5)
        {
            sleep5.SetActive(true);
            yield return new WaitForSeconds(3);
            sleep5.SetActive(false);
        }
        if(sleepDays == 6)
        {
            sleep6End.SetActive(true);
        }
       

    }
}
