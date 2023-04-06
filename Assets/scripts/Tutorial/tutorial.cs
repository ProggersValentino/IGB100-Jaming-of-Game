using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject enemy;
    public float waitTime;
    private float TTD;
    private GameObject[] countE;

    public bool puPicked = false;
    
    //destroying the tutorial base
    public bool withinObjective = false; //gets changed within baseTutorial script
    public bool destroyedBase = false; //gets changed within health script

    [SerializeField] private GameObject tutBase;

    // Update is called once per frame
    void Update()
    {
        popUpChecker();
        countE = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void popUpChecker()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                popUpIndex++;
            }
        }

        if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        }

        if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                popUpIndex++;
            }
        }

        if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                popUpIndex++;
            }
        }

        if (popUpIndex == 4)
        {

            if (waitTime <= 0)
            {
                if (countE.Length <= 0)
                {
                    popUpIndex++;    
                }    
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
        }

        if (popUpIndex == 5)
        {
            if (puPicked)
            {
                popUpIndex++;
            }
        }

        if (popUpIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (popUpIndex == 7)
        {
            if (waitTime <= 0)
            {
                if (countE.Length <= 0)
                {
                    popUpIndex++;    
                }    
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (popUpIndex == 8)
        {
            if (withinObjective)
            {
                tutBase.SetActive(true);
                popUpIndex++;
            }
        }

        if (popUpIndex == 9)
        {
            if (destroyedBase)
            {
                popUpIndex++;
                Invoke("tutUI", 2f);    
            }
            
        }
    }

    void tutUI()
    {
        SceneManager.LoadScene("TutCompleted");
    }
}
