using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] private float defaultCurrentHealth = 100f;
    [SerializeField] private Image healthbarFG;
    public float currentHealth;

    private void Start()
    {
        currentHealth = defaultCurrentHealth;
    }

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