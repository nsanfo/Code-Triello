using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldwestCollider : MonoBehaviour
{
    public string colliderName;
    public GameObject RoomManager;

    // XR Interaction has the tag "Player"
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        Debug.Log("User has entered the " + colliderName);

        // Networking and moving to the old west map!
        RoomManager.GetComponent<RoomManager>().OnEnterButtonClicked_OldWest();
        }
    }
}