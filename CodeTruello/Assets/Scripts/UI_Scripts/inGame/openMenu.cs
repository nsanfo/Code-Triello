using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class openMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public Button resumeButton;
    public Button backToMenuButton;
    public Button exitButton;

    void Start()
    {
        menuCanvas.SetActive(false);
        resumeButton.onClick.AddListener(resumeGame);
        backToMenuButton.onClick.AddListener(backToMenu);
        exitButton.onClick.AddListener(exitGame);
    }

    void Update()
    {
        //if the user presses the A Button, then open or close the menu
        if (Input.GetButtonDown("AButton"))
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }

    void resumeGame()
    {
        //close the menu
        Debug.Log("Resume game clicked");
        menuCanvas.SetActive(false);
    }

    //return to lobby 
    void backToMenu()
    {
        Debug.Log("Return to Menu clicked");
        // networkManager.Instance.LeaveRoomAndLoadHomeScreen();
    }

    void exitGame(){
        Debug.Log("Exit game clicked.");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #endif
        Application.Quit();
    }

}