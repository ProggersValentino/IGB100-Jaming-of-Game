using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUTutorial : MonoBehaviour
{
    private tutorial tut;

    private void Start()
    {
        tut = FindObjectOfType<tutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tut.puPicked = true;
        }
    }
}
