using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

public class WeaponMultiplayerSpawn : MonoBehaviour
{
    private PhotonView photonView;
    public Vector3[] spawnsloc;
    public Transform[] spawnLocs;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(SceneManager.GetActiveScene().name != "Lobby"){ 
            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            float spawnX = spawnLocs[playerCount-1].position.x;
            float spawnY = spawnLocs[playerCount-1].position.y;
            float spawnZ = spawnLocs[playerCount-1].position.z;

            this.gameObject.transform.position = new Vector3(spawnX, spawnY, spawnZ);
            // if(PlayerCount.NumberOfPlayers == 1) {
            //     // the player is local
            //     this.gameObject.transform.position = new Vector3(0, 2, -120);
            //     Debug.Log("I am a local weapon player");
            //     Debug.Log(PlayerCount.NumberOfPlayers);

            // } else if(PlayerCount.NumberOfPlayers != 1) {
            //     // the player is remote

            //     this.gameObject.transform.position = new Vector3(-11, 2, 13);
            //     Debug.Log("I am a remote weapon player");
            //     Debug.Log(PlayerCount.NumberOfPlayers);
           //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
