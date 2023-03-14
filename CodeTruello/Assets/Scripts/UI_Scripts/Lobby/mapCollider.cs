using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCollider : MonoBehaviour
{
    public string colliderName = gameObject.name;
    public string functionName;

    // XR Interaction has the tag "Player"
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("User has entered the " + colliderName);
            Debug.Log("The " + functionName + " function will be called once implemented.");
        }
    }
}