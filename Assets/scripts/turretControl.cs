using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretControl : MonoBehaviour
{
    public float rotationSpeed = 3f; 
    
    //projectile
    public GameObject bullet;
    public float fireRate = 0.15f;

    //to store corroutine
    private Coroutine fireContinuous;
    private bool isFiring;
    [SerializeField] private UICanvas shooting;
    
    //launch point for where the bullet will spawn 
    public Transform ProjLaunchPoint;
    
    //LOS
    [SerializeField] private lineOfSight LOS;

    // Update is called once per frame
    void Update()
    {
        LOS.showLOS(ProjLaunchPoint.position, ProjLaunchPoint.forward * 20);
        turretMovement();
        shoot();
    }

    void turretMovement()
    {
        float rotation = rotationSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, rotation, 0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -rotation, 0f);
        }
    }

    void shoot()
    {
        if(Input.GetKey(KeyCode.Space) && fireContinuous == null) //sets the binding for the player to fire and ensures that the fire rate doesn't match the frame of said pc 
        {
            fireContinuous = StartCoroutine(fireCont());
            shooting.shootDetect = true;
        }
        else if (fireContinuous != null && !isFiring)
        {
            StopCoroutine(fireCont());
            fireContinuous = null;
        }
    }
    
    //sets the firerate for the player's gun
    IEnumerator fireCont()
    {
        isFiring = true;
        Instantiate(bullet, ProjLaunchPoint.position, transform.rotation); //spawns bullet at players location

        yield return new  WaitForSeconds(fireRate);
        isFiring = false;
    }

}
