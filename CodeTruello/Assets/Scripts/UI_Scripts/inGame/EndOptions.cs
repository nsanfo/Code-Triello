using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EndOptions : MonoBehaviour
{
    public string prefabName = "playerPrefab";
    public GameObject winCanvas;
    public GameObject loseCanvas;
    bool isPlayerLeftEnd;




    private Dictionary<healthBar, Canvas> playerCanvases = new Dictionary<healthBar, Canvas>();

    private void Start()
    {
        // checking to see if a player has left for not, so that the canvases don't stay hidden!
        endVisuals endVisualsScript = GetComponent<endVisuals>();
        isPlayerLeftEnd = endVisualsScript.playerLeftEnd;

        // Find all instances of the prefab in the scene
        GameObject[] instancesArray = GameObject.FindGameObjectsWithTag(prefabName);

        foreach (GameObject instance in instancesArray)
        {
            healthBar healthbarScript = instance.GetComponentInChildren<healthBar>();
            Canvas healthbarCanvas = instance.GetComponentInChildren<Canvas>();

            if (healthbarScript == null)
            {
                Debug.LogError("HealthBar component not found on player instance: " + instance.name);
            }
            else if (healthbarCanvas == null)
            {
                Debug.LogError("Canvas component not found on player instance: " + instance.name);
            }
            else
            {
                playerCanvases.Add(healthbarScript, healthbarCanvas);
            }
        }
    }

    private void Update()
    {
        // Check if any player's health is zero
        bool isAnyPlayerDead = false;
        foreach (var playerCanvas in playerCanvases)
        {
            healthBar healthbarScript = playerCanvas.Key;
            Canvas playerCanvasObj = playerCanvas.Value;

            if (healthbarScript.currentHealth == 0)
            {
                isAnyPlayerDead = true;

                // Set the winning player index to the other player
                int winningPlayerIndex = GetWinningPlayerIndex(playerCanvas);

                if (winningPlayerIndex == 0)
                {
                    // Winning player
                    playerCanvasObj.gameObject.SetActive(true);
                    Debug.Log("You won.");
                    loseCanvas.SetActive(false);
                    winCanvas.SetActive(true);
                }
                else
                {
                    // Losing player
                    Debug.Log("You lost.");
                    playerCanvasObj.gameObject.SetActive(false);
                    loseCanvas.SetActive(true);
                }
                healthbarScript.currentHealth = healthbarScript.maxHealth;
                Debug.Log("health reset at:" + healthbarScript.currentHealth);
                break;
            }
        }

        // // If no player is dead, disable both canvases
        // if (!isAnyPlayerDead && isPlayerLeftEnd ==false)
        // {
        //     winCanvas.SetActive(false);
        //     loseCanvas.SetActive(false);
        // }
    }

    private int GetWinningPlayerIndex(KeyValuePair<healthBar, Canvas> playerCanvas)
    {
        healthBar healthbarScript = playerCanvas.Key;

        // Get the index of the winning player
        int playerIndex = 0;
        int winningPlayerIndex = (playerIndex == 0) ? 1 : 0;

        return winningPlayerIndex;
    }
}
