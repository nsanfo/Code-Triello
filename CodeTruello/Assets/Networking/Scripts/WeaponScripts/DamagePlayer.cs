using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    WeaponState state; 
    private void Start() {
        state = this.transform.parent.gameObject.GetComponent<WeaponState>();
    }   
    private void OnTriggerEnter(Collider other) {
        string EnemyTag = "";
        Debug.Log("ok");
        if(other.CompareTag("Player")) {
            EnemyTag = other.transform.parent.gameObject.GetComponent<PlayerState>().playerTag;
            if(EnemyTag != state.weaponOwner.GetComponent<PlayerState>().playerTag) {
                Debug.Log("I am Dealing damage");
            }
        }
        
    }
}
