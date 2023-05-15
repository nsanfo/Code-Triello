using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hideCanvas : MonoBehaviour
{
    public GameObject menuCanvas;
    public Button resumeButton;
    // Start is called before the first frame update
    void Start()
    {
        resumeButton.onClick.AddListener(resumeGame);
    }

    void resumeGame()
    {
        //close the menu
        Debug.Log("Resume game clicked");
        menuCanvas.SetActive(false);
    }
}
