using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class backToMenu : MonoBehaviour
{
    public Button StartButton;
    public Button AboutButton;
    public Button ExitButton;

    public Button backtoMenuButton;
    public GameObject AboutPanel;

    void showMenuButtons()
    {
        //change visibility of buttons
        StartButton.gameObject.SetActive(true);
        AboutButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
        //hide AboutPanel
        AboutPanel.SetActive(false);
    }

    void Start()
    {
        //when AboutButton is clicked, then call function
        backtoMenuButton.onClick.AddListener(showMenuButtons);
    }
}