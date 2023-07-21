using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] Slider healthBar;
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            HandleDeath();
            Debug.Log("Player dead");
        }
        healthBar.value = Mathf.Max( hitPoints, 0f);
        
    }
    public void HandleDeath()
    { 

        FindObjectOfType<GameOverHandler>().DisplayGameOverCanvas("You Dead");
    }
}
