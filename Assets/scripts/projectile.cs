using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float LTime = 3f; //sec
    public float BSpeed = 50f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, LTime); //will destroy bullet after the life time that has been set 
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        transform.position += Time.deltaTime * BSpeed * transform.forward;
    }
}    