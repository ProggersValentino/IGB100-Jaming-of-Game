using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//this code was provided by Dave / GameDevelopment (https://www.youtube.com/watch?v=UjkSFoLxesw)
public class NavMeshAI : MonoBehaviour
{
    //projectile
    public GameObject bullet;
    public float fireRate = 0.15f;
    private float fireTime;

    //launch point for where the bullet will spawn 
    public Transform ProjLaunchPoint;
    public GameObject turret;
    enemyTurret rotatT;

    //AI related
    public NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsPlayer, whatIsGround;
    

    //patroling
    public Vector3 walkPoint;
    bool WPSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool attackDone;

    //states
    public float sightRange, attackRange;
    public bool playerISRange, playerIARange;

    void Awake() 
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();    
    }

    void Start()
    {
        rotatT = GetComponent<enemyTurret>();
    }

    void Update() 
    {
        //setting the ranges for the sight range and attack range of the AI 
        playerISRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerIARange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerISRange && !playerIARange)
        {
            Patroling();
        }

        if(playerISRange && !playerIARange)
        {
            ChaseP();
        }

        if(playerISRange && playerIARange)
        {
            AttackP();
        }

        //float EnSpeed = agent.acceleration;
        //Debug.Log(EnSpeed);
    }
    
    void Patroling() 
    {
        if(!WPSet)
        {
            searchWalkPoint();
        }

        if(WPSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if(distToWalkPoint.magnitude < 1f)
        {
            WPSet = false; //resetting the walkpoint calculation to generate another coord for the AI to lock onto
        }
    }

    void searchWalkPoint()
    {
        //calculate a random point to go to
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); //coords for AI

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            WPSet = true;
        }

    }

    void ChaseP() 
    {
        agent.SetDestination(player.position);
    }

    void AttackP() 
    {
        //make sure enemy doesnt move when attacking
        agent.SetDestination(transform.position);

        //transform.LookAt(player); //consistently faces the player

        //AI will attack player if it hasnt already
        if(!attackDone)
        {
            Instantiate(bullet, ProjLaunchPoint.position, turret.transform.rotation); //spawns bullet at players location

            attackDone = true;
            Invoke(nameof(resetAtt), timeBetweenAttacks);
        }
    }

    void resetAtt()
    {
        attackDone = false;
    }


    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

       

}
