using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class objectiveUI : MonoBehaviour
{
    public GameObject[] objectives;
    private int objecIndex;
    
    //objectives 
    public bool entObjec1 = false;
    public bool destroyB1;
    public bool entObjec2;
    public bool destroyB2;
    public bool entObjec3;
    public bool destroyB3;
    
    MainMenu UI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UI = FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        objecveFunction();
    }

    public void objecveFunction()
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if (i == objecIndex)
            {
                objectives[i].SetActive(true);
            }
            else
            {
                objectives[i].SetActive(false);
            }
        }

        if (objecIndex == 0)
        {
            if (entObjec1)
            {
                objecIndex++;
            }
        }
        else if (objecIndex == 1)
        {
            if (destroyB1)
            {
                objecIndex++;    
            }
        }
        else if (objecIndex == 2)
        {
            if (entObjec2)
            {
                objecIndex++;
            }
        }
        else if (objecIndex == 3)
        {
            if (destroyB2)
            {
                objecIndex++;
            }
        }
        else if (objecIndex == 4)
        {
            if (entObjec3)
            {
                objecIndex++;
            }
        }
        else if (objecIndex == 5)
        {
            if (destroyB3)
            {
                objecIndex++;
                // Invoke("winScreen", 1.5f);
                UI.loadWin();
            }
        }
        
    }
    
    void winScreen()
    {
        UI.loadWin();
    }
}
