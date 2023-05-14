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
    public Transform[] spawnsloc;
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
            float spawnX = spawnsloc[playerCount-1].position.x;
            float spawnY = spawnsloc[playerCount-1].position.y;
            float spawnZ = spawnsloc[playerCount-1].position.z;


            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
