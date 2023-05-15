using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endVisuals : MonoBehaviour
{
    public bool playerLeftEnd;
    private healthBar healthbarScript;
    public GameObject endCanvas;
    public GameObject healthBar;

    void Start()
    {
        playerLeftEnd = false;
        healthbarScript = healthBar.GetComponent<healthBar>();
    }

    public void EndGameFunction()
    {
        playerLeftEnd = true;
        endCanvas.SetActive(true);
        float maxHealth = healthbarScript.playerAttributeSet.GetMaxHealth();
        float currentHealth = healthbarScript.playerAttributeSet.GetCurrentHealth();
        currentHealth = maxHealth;

        Debug.Log("Current Health (should be reset to full): " + currentHealth);
    }
}