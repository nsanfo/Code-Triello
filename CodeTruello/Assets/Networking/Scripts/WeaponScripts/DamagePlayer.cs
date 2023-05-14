 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // [SerializeField]
    // WeaponState WS;
    [SerializeField]
    GameObject Player;
    PlayerState PS_Player;
    GameObject Enemy;
    PlayerState PS_Enemy;
    [SerializeField]
    float damage;
    private void Start() {
    }  
    private void Update() {
        // if(WS != null) {
        //     Player = WS.weaponOwner.gameObject;
        // }
    } 
    private void OnTriggerEnter(Collider other) {
        string EnemyTag;
        //AttributeSet set = PS_Player.PlayerAttribute
        if(other != null) {
            EnemyTag = other.transform.gameObject.tag;
            if(EnemyTag != Player.tag) {
                if(EnemyTag == "Player1" || EnemyTag == "Player2") {
                    Enemy = other.transform.gameObject;
                    PS_Enemy = Enemy.GetComponent<PlayerState>();
                    Debug.Log("1) " + Player.tag);
                    Debug.Log("2) " + EnemyTag);
                    if(PS_Enemy != null) {
                        PS_Enemy.TakingDamage(damage);
                    }
                    //PS_Enemy = Enemy.transform.parent.gameObject.GetComponent<PlayerState>();
                    Debug.Log("I am Dealing damage");

                }
            }
        }
    }

}
