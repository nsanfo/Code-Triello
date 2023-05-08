using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class quitGame : MonoBehaviour
{
    public Button ExitButton;

    public void exitGame()
    {
        Debug.Log("Exit game clicked.");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #endif
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        ExitButton.onClick.AddListener(exitGame);
    }
}
