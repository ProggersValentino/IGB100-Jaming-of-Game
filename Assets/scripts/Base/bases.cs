using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bases : MonoBehaviour
{
    public enum enemyBaseType{base1, base2, base3};

    public enemyBaseType baseSelection;
    
    public enum objectiveType{missionEnt1, missionEnt2, missionEnt3};

    public objectiveType missionSelection;
    
    public GameObject boss;
    [SerializeField] private GameObject nextBase;
    [SerializeField] GameObject objectiveArea;

    private objectiveUI quests;
    

    private void Awake()
    {
        quests = FindObjectOfType<objectiveUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (missionSelection == objectiveType.missionEnt1)
            {
                quests.entObjec1 = true;
                objActive(false);
                Debug.Log("we are starting");    
            }
            else if (missionSelection == objectiveType.missionEnt2)
            {
                quests.entObjec2 = true;
                objActive(false);
            }
            else if (missionSelection == objectiveType.missionEnt3)
            {
                quests.entObjec3 = true;
            }
            
        }
    }

    public void objActive(bool settingactive)
    {
        objectiveArea.SetActive(settingactive);
    }

    public void baseActive(bool isActive)
    {
        if (nextBase != null)
        {
            nextBase.SetActive(isActive);
        }
        else
        {
            Debug.Log("hi");
        }
    }

    
}
