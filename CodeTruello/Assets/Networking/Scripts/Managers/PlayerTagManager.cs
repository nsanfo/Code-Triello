using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerTagManager : MonoBehaviour
{
    Player[] players;
    public string[] tags;
    void Start()
    {
        players = PhotonNetwork.PlayerList;
        for(int i = 0; i < players.Length; i++) {
            Debug.Log(players[i]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
