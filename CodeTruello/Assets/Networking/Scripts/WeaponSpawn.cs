using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject GenericVRPlayerPrefab;
    SpawnManager wpnType;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is touching me.");
            if(wpnType == null) {
                wpnType = GenericVRPlayerPrefab.GetComponent<SpawnManager>();
                wpnType.SpawnCharWeapon = this.gameObject;
            }
            
            
        }
    }
    // private void Awake()
    // {
    //     DontDestroyOnLoad(gameObject);
    // }
}
