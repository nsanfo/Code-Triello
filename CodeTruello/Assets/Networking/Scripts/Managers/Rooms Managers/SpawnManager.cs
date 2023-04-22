using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class SpawnManager : MonoBehaviour
{

    static int spawnIndex;
    [SerializeField]
    GameObject GenericVRPlayerPrefab;
    public Vector3 SpawnPoint;
    public Vector3[] spawnsloc;
    public string[] playertags;

    
    // PhotonView myPV;
    // GameObject myPlayerAvatar;

    // Player[] allPlayers;
    // int myNumberInRoom;

    void Start()
    {   //Player[] otherPlayers = PhotonNetwork.CurrentRoom.GetPlayerListOthers();
        Debug.Log("CurrentPlayerCount" +  PhotonNetwork.CurrentRoom.PlayerCount);
        if(PhotonNetwork.IsConnectedAndReady) {
            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            // if(GenericVRPlayerPrefab.GetComponent<PhotonView>().IsMine) {
            //     GenericVRPlayerPrefab.GetComponent<PlayerState>().playerTag = playertags[playerCount-1];
            // } else {
            //     GenericVRPlayerPrefab.GetComponent<PlayerState>().playerTag = playertags[playerCount-1];
            // }


            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnsloc[playerCount-1], Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
