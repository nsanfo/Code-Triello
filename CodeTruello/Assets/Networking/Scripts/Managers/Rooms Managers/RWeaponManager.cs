using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RWeaponManager : MonoBehaviour
{
    GameObject LobbyWeaponManager;
    LWeaponManager wpn;
    public Transform[] spawnLocs;
    public Vector3 spawnPosition;
    void Start()
    {
        if(PhotonNetwork.IsConnectedAndReady) {
            LobbyWeaponManager = GameObject.Find("Lobby Weapon Manager");

            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            float spawnX = spawnLocs[playerCount-1].position.x;
            float spawnY = spawnLocs[playerCount-1].position.y;
            float spawnZ = spawnLocs[playerCount-1].position.z;


            wpn = LobbyWeaponManager.GetComponent<LWeaponManager>();
            if(wpn.ObjectName == "GunModel 1") {
                PhotonNetwork.Instantiate("GunModel 1", new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
            } else if(wpn.ObjectName == "Sword") {
                PhotonNetwork.Instantiate("Sword 1", new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
            } else if(wpn.ObjectName == "Wand") {
                PhotonNetwork.Instantiate("Wand 1", new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
            }
        }
        
        //Debug.Log(wpn.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
