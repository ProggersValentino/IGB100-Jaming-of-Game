using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using Unity.VisualScripting;

public class player : MonoBehaviour
{
    [SerializeField] float MSped = 5f; 
    public float rotationSpeed = 100f;
    Vector3 position;
    
    Rigidbody rb; 
    public Transform orientation;
    
    //ability related
    public bool abilityOn;
    private Coroutine ramAbility;
    
    //UI related
    [SerializeField] UICanvas ability;
    
    //damage mod
    private DamageDealer damageMod;


    //boundary variables 
    public Vector3 BoundMax;
    public Vector3 BoundMin;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    //ability related
    public float abCooldown = 2f;
    public float forceApp = 20f;

    [SerializeField] private ParticleSystem dustDriving;


    // Start is called before the first frame update
    void Start()
    {
        // dustDriving.Stop();
        rb = GetComponent<Rigidbody>();
        damageMod = GetComponent<DamageDealer>();
    }


    void Update()
    {
        abilityCentre();
    }

    // this is called once every physic frame 
    void FixedUpdate()
    {
        PMove();
        boundary();
        
    }

    void PMove()
    {
        //using old unity input system through accessing the Horizontal and Vertical Axis within the settings (which already have bindings within)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        
        moveDirection = orientation.forward * verticalInput * Time.fixedDeltaTime; //calculating the orientation for the player for the force   
        rb.AddForce(moveDirection.normalized * MSped * 10f, ForceMode.Impulse); //adds a consistent force everytime a certain key is held down 
        // if (moveDirection.normalized == Vector3.zero)
        // {
        //     dustDriving.emission.rateOverTime = 0;
        // }
        // else
        // {
        //     Debug.Log("particle go weee");
        //     dustDriving.Play();
        // }
        
        
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.fixedDeltaTime, 0));
    }
    

    //boundary for player using physics based 
    void boundary()
    {
        float x = Mathf.Clamp(transform.position.x, BoundMin.x, BoundMax.x);
        float z = Mathf.Clamp(transform.position.z, BoundMin.z, BoundMax.z);
        Vector3 newPos = new Vector3(x, transform.position.y, z);
        rb.MovePosition(newPos);
    }

    public void abilityCentre()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !abilityOn)
        {
            ramAbility = StartCoroutine(ram());
            ability.abDetect = true;
        }
        
        
    }

    IEnumerator ram()
    {
        abilityOn = true;
        moveDirection = orientation.forward * Time.deltaTime; //calculating the orientation for the player for the force   
        damageMod.damage += 30;
        
        rb.AddForce(moveDirection.normalized * forceApp, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        damageMod.damage -= 30;
        yield return new WaitForSecondsRealtime(abCooldown);
        
        abilityOn = false;
    }
}
