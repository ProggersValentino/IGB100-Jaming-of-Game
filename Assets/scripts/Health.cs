using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    public float health = 50;
    // [SerializeField] int score = 50;
    private Rigidbody rb;

    private GameOver gameOver;

    private objectiveUI quests;

    private bases baseFunc;

    private tutorial tut;
    
    CameraShake cameraShake;
    [SerializeField] private bool applyShake;

    private void Awake()
    {
        gameOver = FindObjectOfType<GameOver>();
        quests = FindObjectOfType<objectiveUI>();
        baseFunc = FindObjectOfType<bases>();
        tut = FindObjectOfType<tutorial>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void OnTriggerEnter(Collider other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        player ram = other.GetComponent<player>();
        //bool damageDealer = other.TryGetComponent<DamageDealer>(out DamageDealer d);

        if(damageDealer != null && other.CompareTag("bullet"))
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
        
        if(other.CompareTag("Player"))
        {
            Debug.Log("damage DOne");
            // Debug.Log(gameObject.name);
            // Debug.Log(other.name); 
            TakeDamage(damageDealer.GetDamage());
        }
        // if (other.CompareTag("objective"))
        // {
        //     quests.entObjec1 = true;
        //     
        //     Debug.Log("we are starting");
        // }


    }



    public void TakeDamage(int damage){ 
        health -= damage;
        Debug.Log(health);
            
        healthCheck();
       
    }
    
    public void healthCheck()
    {
        if(health <= 0){
            Die();
        }
    }

    // when player and/or enemy dies 
    void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            GetComponent<LootBag>().spawnPU(transform.position);
        }
        else if(gameObject.CompareTag("Player"))
        {
            gameOver.loadGameOver();
        }
        else if (gameObject.CompareTag("tutorial"))
        {
            tut.destroyedBase = true;
        }
        else 
        {

            if (gameObject.CompareTag("baseObj") && baseFunc.baseSelection == bases.enemyBaseType.base1)
            {
                Debug.Log("mission complete");
                quests.destroyB1 = true;  
                baseFunc.baseActive(true);
            }
            else if (gameObject.CompareTag("baseObj") && baseFunc.baseSelection == bases.enemyBaseType.base2)
            {
                Debug.Log("base 2 gonnas");
                quests.destroyB2 = true;
                baseFunc.baseActive(true);
            }
            else if (gameObject.CompareTag("baseObj") && baseFunc.baseSelection == bases.enemyBaseType.base3)
            {
                quests.destroyB3 = true;
            }
            
        }
        Destroy(gameObject);
            
    }


    // get the health
    public float returnHealth()
    {
        return health;
    }
    
    
}
