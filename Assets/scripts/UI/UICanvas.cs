
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class UICanvas : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [SerializeField] Image abImageCD;
    [SerializeField] Image frImageCD;
    // [SerializeField] TMP_Text textCD;
    
    //ability cooldown related
    public bool isCD = false;
    [SerializeField] private float CDTime = 10f;
    private float CDTimer = 0f;
    public bool abDetect; //gets called from player script
   
    //fire rate related 
    public bool shootDetect; //gets changed within turretController
    private float fireCDTime;
    private float fireCDTimer = 0f;
    
    //scripts needed for UI
    [SerializeField] private turretControl Tcontroller;
    
    
    // [SerializeField] TextMeshProUGUI healthText;
    //
    // [Header("Score")]
    // [SerializeField] TextMeshProUGUI scoreText;
    // ScoreKeeper scoreKeeper;

    void Awake() 
    {
        // scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.returnHealth();
        // textCD.gameObject.SetActive(false);
        abImageCD.fillAmount = 0f;
        frImageCD.fillAmount = 0f;
        CDTimer = CDTime; // ensuring that the timer is set
        
        fireCDTime = Tcontroller.fireRate;
        fireCDTimer = fireCDTime; //sets cooldown based on what fire rate has been set
        
    }


    void Update()
    {
        healthSlider.value = playerHealth.returnHealth();
        // healthText.text = playerHealth.returnHealth().ToString();
        // scoreText.text = scoreKeeper.returnScore().ToString("000000000");

        if (abDetect)
        {
            applyCD();
            // Debug.Log("working");
        }

        if (shootDetect)
        {
            frApplyCD();
        }
        
        
    }
    
    //cooldown for ability
    void applyCD()
    {
        
        //subtrack time from when last called
        CDTimer -= Time.deltaTime;

        if (CDTimer <= 0f)
        {
            abDetect = false;
            abImageCD.fillAmount = 0f;
            CDTimer = CDTime;

        }
        else
        {
            // textCD.text = Mathf.RoundToInt(CDTimer).ToString();
            abImageCD.fillAmount = CDTimer / CDTime;
        }
        
    }
    
    //cooldown for firerate 
    void frApplyCD()
    {
        
        //subtrack time from when last called
        fireCDTimer -= Time.deltaTime;

        if (fireCDTimer <= 0f)
        {
            shootDetect = false;
            frImageCD.fillAmount = 0f;
            fireCDTimer = fireCDTime;
        }
        else
        {
            // textCD.text = Mathf.RoundToInt(CDTimer).ToString();
            frImageCD.fillAmount = fireCDTimer / fireCDTime;
        }
        
    }
    
}
