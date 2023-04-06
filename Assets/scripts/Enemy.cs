using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chasePlayer();
    }

    void chasePlayer()
    {
        if(GameManager.instance.player)
        {
            transform.LookAt(GameManager.instance.player.transform.position);
        }

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
