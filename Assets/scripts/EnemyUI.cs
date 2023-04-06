using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  

public class EnemyUI : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    
    
    void Awake() 
    {
        // scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.returnHealth();
        // textCD.gameObject.SetActive(false);
    }


    void Update()
    {
        healthSlider.value = playerHealth.returnHealth();
        // healthText.text = playerHealth.returnHealth().ToString();
        // scoreText.text = scoreKeeper.returnScore().ToString("000000000");
        
    }

    
}
