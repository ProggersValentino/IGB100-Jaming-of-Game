using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCustomize : MonoBehaviour
{
    //assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies; //detects whether it is an enemy 

    //stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool usesGravity;

    //damage
    public int explosionDmg;
    public float explosionRnge;
    public float explosionFce;

    //LifeTime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial phys_mat;

    void Start() 
    {
        Setup();    
    }
    void Update() 
    {
        //checking when to explode
        if (collisions > maxCollisions)
        {
            explode();
        }

        //count down lifetime
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0)
        {
            explode();
        }
    }

    void OnCollisionEnter(Collision collision) 
    {
        //count up collisions
        collisions++;

        //explode if bullet hits an enemy directly and explodeOnTouch is activated
        if(collision.collider.CompareTag("Enemy") && explodeOnTouch) explode();
    }

    void explode()
    {
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        //check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRnge, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call TakeDamage

            //eg 
            //enemies[i].GetComponent<ShootingAi>().TakeDamage(explosionDamage)

            //add explosion force to enemy (if enemy has a rigid body)
            if(enemies[i].GetComponent<Rigidbody>())
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionFce, transform.position, explosionRnge);
            }
        }

        //checking to saee if works 
        Invoke("Delay", 0.05f);
    }

    void Delay()
    {
        Destroy(gameObject);
    }

    void Setup()
    {
        //create a new physic material
        phys_mat = new PhysicMaterial();
        phys_mat.bounciness = bounciness;
        //to ensure the bullet bounces well 
        phys_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        phys_mat.bounceCombine = PhysicMaterialCombine.Maximum;

        //assign material to collider
        GetComponent<SphereCollider>().material = phys_mat;

        //use grav
        rb.useGravity = usesGravity;

    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRnge);
    }
}
