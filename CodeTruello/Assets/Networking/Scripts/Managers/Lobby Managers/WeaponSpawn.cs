using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    [SerializeField]
    LWeaponManager wpnManager;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is touching me.");
            if(wpnManager != null) {
                wpnManager.ObjectName = this.gameObject.name;
            }
        }
    }
}
