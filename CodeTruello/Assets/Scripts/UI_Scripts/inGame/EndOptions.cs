using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EndOptions : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject loseCanvas;
    bool isPlayerLeftEnd;

    private Dictionary<healthBar, Canvas> playerCanvases = new Dictionary<healthBar, Canvas>();
        
    private void Start()
    {
        // Checking to see if a player has left or not, so that the canvases don't stay hidden!
        endVisuals endVisualsScript = GetComponent<endVisuals>();
        isPlayerLeftEnd = endVisualsScript.playerLeftEnd;

        // Find all instances of the player objects in the scene
        GameObject[] player1Array = GameObject.FindGameObjectsWithTag("Player1");
        GameObject[] player2Array = GameObject.FindGameObjectsWithTag("Player2");

        // Find health bars and canvases for Player 1
        foreach (GameObject player1 in player1Array)
        {
            if (player1.name.Contains("playerPrefab"))
            {
                healthBar healthbarScript = player1.GetComponentInChildren<healthBar>();
                Canvas healthbarCanvas = player1.GetComponentInChildren<Canvas>();

                if (healthbarScript == null)
                {
                    Debug.LogError("HealthBar component not found on Player 1 instance: " + player1.name);
                }
                else if (healthbarCanvas == null)
                {
                    Debug.LogError("Canvas component not found on Player 1 instance: " + player1.name);
                }
                else if (!playerCanvases.ContainsKey(healthbarScript))
                {
                    playerCanvases.Add(healthbarScript, healthbarCanvas);
                }
            }
        }

        // Find health bars and canvases for Player 2
        foreach (GameObject player2 in player2Array)
        {
            if (player2.name.Contains("playerPrefab"))
            {
                healthBar healthbarScript = player2.GetComponentInChildren<healthBar>();
                Canvas healthbarCanvas = player2.GetComponentInChildren<Canvas>();

                if (healthbarScript == null)
                {
                    Debug.LogError("HealthBar component not found on Player 2 instance: " + player2.name);
                }
                else if (healthbarCanvas == null)
                {
                    Debug.LogError("Canvas component not found on Player 2 instance: " + player2.name);
                }
                else if (!playerCanvases.ContainsKey(healthbarScript))
                {
                    playerCanvases.Add(healthbarScript, healthbarCanvas);
                }
            }
        }
    }private void Update()
{
    // Check if any player's health is zero
    bool isAnyPlayerDead = false;
    foreach (var playerCanvas in playerCanvases)
    {
        healthBar healthbarScript = playerCanvas.Key;
        Canvas playerCanvasObj = playerCanvas.Value;

        float currentPlayerHealth = healthbarScript.playerAttributeSet.GetCurrentHealth();
        string playerName = (playerCanvas.Key.tag == "Player1") ? "Player 1" : "Player 2";
        Debug.Log(playerName + " health: " + currentPlayerHealth);


        if (currentPlayerHealth <= 0)
        {
            isAnyPlayerDead = true;
            Debug.Log("A player has died.");

            // Set the winning player index to the other player
            int winningPlayerIndex = GetWinningPlayerIndex(healthbarScript);
            if (winningPlayerIndex == 0)
            {
                // Winning player
                playerCanvasObj.gameObject.SetActive(true);
                winCanvas.SetActive(true);
                loseCanvas.SetActive(false);
                Debug.Log("Player 1 won.");
            }
            else
            {
                // Losing player
                playerCanvasObj.gameObject.SetActive(false);
                loseCanvas.SetActive(true);
                winCanvas.SetActive(false);
                Debug.Log("Player 2 won.");
            }
            break;
        }
    }

    // If no player is dead, disable both canvases
    if (!isAnyPlayerDead && !isPlayerLeftEnd)
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }
}

    // Winning player = 0
    private int GetWinningPlayerIndex(healthBar playerHealthBar)
    {
        int playerIndex = 0;

        foreach (var playerCanvas in playerCanvases)
        {
            if (playerCanvas.Key == playerHealthBar)
            {
                break;
            }

            playerIndex = (playerIndex + 1) % 2;
        }
        return playerIndex;
    }
    }