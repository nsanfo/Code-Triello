using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class LoginManager : MonoBehaviourPunCallbacks // access photon call backs
{
    public TMP_InputField PlayerName_InputName;
    #region UNITY METHODS
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region UI CALLBACK METHODS
    public void ConnectAnonymously() {
        // connect player to Photon
        PhotonNetwork.ConnectUsingSettings();
    }
    public void ConnectToPhotonServer() {
        if(PlayerName_InputName != null) {
            //this set the player name that will become the identity in the virtual room
            PhotonNetwork.NickName = PlayerName_InputName.text;
            // connect player to Photon
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    #endregion

    #region PHOTON CALLBACK METHODS
    // this will be called when an internet is established
    // the first thing that will be called when we initialized the connection process
    // when this is called the server is available
    public override void OnConnected() 
    {
        Debug.Log("OnConnected is called. The server is available!");
    }
    // this will be called when the user is successfully connected to the server
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server" + PhotonNetwork.NickName);
        //load a level
        PhotonNetwork.LoadLevel("MainScreen");
    }

    #endregion
}
