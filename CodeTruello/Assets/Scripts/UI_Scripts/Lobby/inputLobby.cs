using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputLobby : MonoBehaviour
{
    public GameObject RoomManager; // Reference to the other object that has the script with the function

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed!");

            // Call the function on the other object
            RoomManager.GetComponent<RoomManager>().OnEnterButtonClicked_OldWest();
        }
    }
}