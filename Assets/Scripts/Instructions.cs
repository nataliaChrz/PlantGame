using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{

    public GameObject startText;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startText.SetActive(true);

        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.C))
        {
            

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startText.SetActive(false);

            Destroy(gameObject);
        }
    }
}
