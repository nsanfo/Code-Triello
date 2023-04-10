using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public Button resumeButton;
    public Button exitButton;

    void Start()
    {
        menuCanvas.SetActive(false);
        resumeButton.onClick.AddListener(resumeGame);
        exitButton.onClick.AddListener(closeGame);
    }

    void Update()
    {
        if (Input.GetButtonDown("AButton"))
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }

    void resumeGame()
    {
        Debug.Log("Resume game clicked");
    }

    void closeGame()
    {
        Debug.Log("Close game clicked");
        menuCanvas.SetActive(false);
    }
}