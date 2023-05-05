using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endVisuals : MonoBehaviour
{
    private healthBar healthbarScript;
    public GameObject endCanvas;
    public GameObject healthBar;

    void Start()
    {
        healthbarScript = healthBar.GetComponent<healthBar>();
    }

    public void EndGameFunction()
    {
        endCanvas.SetActive(true);
        // healthbarScript.currentHealth = healthbarScript.maxHealth;
        Debug.Log("Healthbar needs to be set to full health!");
    }
}