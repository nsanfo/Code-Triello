using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private Image healthbarFG;
    // Start is called before the first frame update
    public void UpdateHealthBar(float maxHealth, float currentHealth){
        healthbarFG.fillAmount = currentHealth / maxHealth;
    }
}
