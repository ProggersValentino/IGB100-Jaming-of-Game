using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Temporary")]
public class temporaryBuff : PowerUpSO
{
    //buff type selection
    public enum buffType {health, fireRate, InfiniteRam}
    public buffType buffSelection;

    // required variables for object to work
    public float amount;
    public float OGV;
    [SerializeField] float timeLength;
    
    
    //misc info
    public Sprite PUSprite;
    public string PUName;
    public float dropChance;

    public void Loot(string PUName, float dropChance)
    {
        this.PUName = PUName;
        this.dropChance = dropChance;
    }

    public override void Apply(GameObject target)
    {
        if (buffSelection == buffType.fireRate)
        {
            target.GetComponentInChildren<turretControl>().fireRate = amount;
        }
        else if (buffSelection == buffType.health)
        {
            target.GetComponent<Health>().health = amount;
        }
        
       
    }

    public override void RTOV(GameObject BgValue)
    {
        if (buffSelection == buffType.fireRate)
        {
         BgValue.GetComponentInChildren<turretControl>().fireRate = OGV;
        }
        else if (buffSelection == buffType.health)
        {
            BgValue.GetComponent<Health>().health = OGV;
        }
    }

    // returns the time length
    public override float returnTime()
    {
        return timeLength;
    }
    

    
}
