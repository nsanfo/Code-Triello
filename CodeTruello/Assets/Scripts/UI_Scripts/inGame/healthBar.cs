using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private Image healthbarFG;
    public float maxHealth;
    public float currentHealth;

    // Call UpdateHealthBar every frame
    private void Update()
    {
        UpdateHealthBar(maxHealth, currentHealth);
    }

    // Update the health bar fill amount based on current and max health
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthbarFG.fillAmount = currentHealth / maxHealth;
    }
}