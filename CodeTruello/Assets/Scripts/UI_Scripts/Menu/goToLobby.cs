using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goToLobby : MonoBehaviour
{
    public Button StartButton;
    public GameObject LoginUIScene;

    public void lobbyScene() {
        Debug.Log("Sent to Lobby");
        // Main Menu = Scene 0
        // Sample Scene = Scene 1
        SceneManager.LoadScene(1); //Will change depending on what the lobby scene is. This currently sends the user to the "Sample Scene"
    }

    void Start()
    {
        StartButton.onClick.AddListener(lobbyScene);
    }
}
