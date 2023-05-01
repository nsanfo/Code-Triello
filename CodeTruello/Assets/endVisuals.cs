using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class endVisuals : MonoBehaviour
{
    public GameObject endCanvas;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGameFunction()
    {
        endCanvas.SetActive(true);
        healthBar.SetActive(false);
    }
}
