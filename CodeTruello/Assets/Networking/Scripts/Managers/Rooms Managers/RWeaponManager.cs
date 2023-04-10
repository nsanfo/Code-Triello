using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RWeaponManager : MonoBehaviour
{
    GameObject LobbyWeaponManager;
    LWeaponManager wpn;
    public Vector3 spawnPosition;
    void Start()
    {
        if(PhotonNetwork.IsConnectedAndReady) {
            LobbyWeaponManager = GameObject.Find("Lobby Weapon Manager");
            wpn = LobbyWeaponManager.GetComponent<LWeaponManager>();
            if(wpn.ObjectName == "GunModel 1") {
                PhotonNetwork.Instantiate("GunModel 1", spawnPosition, Quaternion.identity);
            } else if(wpn.ObjectName == "Sword") {
                PhotonNetwork.Instantiate("Sword 1", spawnPosition, Quaternion.identity);
            } else if(wpn.ObjectName == "Wand") {
                PhotonNetwork.Instantiate("Wand 1", spawnPosition, Quaternion.identity);
            }
        }
        
        //Debug.Log(wpn.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
