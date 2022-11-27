using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private GameObject nearTo = null;

    public int sleepDays;
    
    void Start()
    {
        sleepDays = 0;
    }

    
    private void Update()
    {
        if (nearTo != null && Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Key Press");

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
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearTo = null;
        }
    }

    public void Water()
    {
        if(PlantPot.water == 2)
        {
            //Plant grows
            

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
    }
}
