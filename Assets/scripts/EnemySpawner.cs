using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 1.0f;

    public GameObject[] enemyPrefb;
    GameObject[] countEnemy;
    int count;

    public bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        countEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        //count = countEnemy.Length;

    }

    IEnumerator spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true) 
        {
            yield return wait; //pause while loop every frame so no crash
            
            Debug.Log(countEnemy.Length);

            if (countEnemy.Length < 6) //controls the max amount of spawning so that it doesnt overwhelm player
            {
              enemyS();
            }

        }
    }

    void enemyS()
    {
        int rand = Random.Range(0, enemyPrefb.Length); //cycles through randomly spawning an enemy

        GameObject enemyToSpawn = enemyPrefb[rand];

        Instantiate(enemyToSpawn, transform.position, Quaternion.identity); //spawns enemy at the spawner position
    }
}

