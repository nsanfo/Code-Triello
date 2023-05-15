using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private Image healthbarFG;
    public AttributeSet playerAttributeSet;

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float currentHealth = playerAttributeSet.GetCurrentHealth();
        float maxHealth = playerAttributeSet.GetMaxHealth();
        healthbarFG.fillAmount = currentHealth / maxHealth;
    }
}