using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyTurret : MonoBehaviour
{
    //AI related
    private Transform player;
    public LayerMask whatIsPlayer, whatIsGround;

    //states
    public float sightRange, attackRange;
    public bool playerISRange, playerIARange;

    //turret
    public float rotSpeed;

    Quaternion rotation;

    void Awake()
    {
        player = GameObject.Find("player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        //setting the ranges for the sight range and attack range of the AI 
        playerISRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerIARange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerISRange && playerIARange)
        {
            //Debug.Log(rotation.normalized);
            turretLook();
        }

    }

    void turretLook()
    {

        rotation = Quaternion.LookRotation(player.position - transform.position); //calculate of the rotation needed to face the player
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * rotSpeed); //consistently faces the player with a delay

    }

    void enemyFire()
    {

    }

  

}
