using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCat : MonoBehaviour
{
    public GameObject catText;
    public ParticleSystem catParticle;
   

    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            catText.SetActive(true);

        }
       
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.C))
        {

            catParticle.Play();

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            catText.SetActive(false);
        }
    }
}
