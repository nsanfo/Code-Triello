using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class replayGame : MonoBehaviour
{
    Button replayButton;
    GameObject winCanvas;
    GameObject loseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        replayButton.onClick.AddListener(replay);
    }

    void replay()
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }
}
