using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Powerups : MonoBehaviour
{
    public PowerUpSO PUEffect;

    // public GameObject PUGen;
    // public List<temporaryBuff> lootList = new List<temporaryBuff>();
    //
    // temporaryBuff getDroppedPU()
    // {
    //     float ranNum = Random.Range(1f, 101f); // going from 1 - 100 
    //     List<temporaryBuff> possiblePUs = new List<temporaryBuff>();
    //
    //     foreach (temporaryBuff PU in lootList)
    //     {
    //         if (ranNum <= PU.dropChance)
    //         {
    //             possiblePUs.Add(PU); //
    //         }
    //
    //         if (possiblePUs.Count > 0) //checking to see if there are any power ups to drop based on drop chance
    //         {
    //             temporaryBuff droppedPU = possiblePUs[Random.Range(0, possiblePUs.Count)]; //if there is a possibility then it will choose 
    //             PUEffect = droppedPU;
    //             Debug.Log(PUEffect);
    //             return droppedPU;
    //         }
    //         
    //     }
    //     return null;
    // }
    //
    // //spawning the loot
    // public void spawnPU(Vector3 spawnPos)
    // {
    //     temporaryBuff droppedPU = getDroppedPU();
    //     if (droppedPU != null)
    //     {
    //         GameObject puGameObject = Instantiate(PUGen, spawnPos, Quaternion.identity); //spawns the powerup
    //         puGameObject.GetComponent<SpriteRenderer>().sprite = droppedPU.PUSprite;
    //     }
    // }
    
    // powerup activation
    private void OnTriggerEnter(Collider collision) {
        
        if(collision.CompareTag("Player"))
        {
            Debug.Log("im detected");
            StartCoroutine(PUActivation(collision)); //activating coroutine
        }
        
    }

    // temporary buff activation through a coroutine
    public IEnumerator PUActivation(Collider collision)
    {
        PUEffect.Apply(collision.gameObject); //changed value
        
        GetComponent<SpriteRenderer>().enabled = false;

        Debug.Log("start duration");
        yield return new WaitForSeconds(PUEffect.returnTime()); // the duration for changed value

        Debug.Log("co donbe");
        PUEffect.RTOV(collision.gameObject); // original value

        Destroy(gameObject);
    }



   
}
