using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class goToAbout : MonoBehaviour
{
    public Button StartButton;
    public Button AboutButton;
    public Button ExitButton;

    public GameObject AboutPanel;

    void hideMenuButtons()
    {
        //change visibility of buttons
        StartButton.gameObject.SetActive(false);
        AboutButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        //show AboutPanel
        AboutPanel.SetActive(true);
    }

    void Start()
    {
        //when AboutButton is clicked, then call function
        AboutButton.onClick.AddListener(hideMenuButtons);
    }
}
