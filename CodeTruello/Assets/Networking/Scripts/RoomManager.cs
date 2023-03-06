using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    private string mapType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI Callback Methods 
    public void JoinRandomRoom() {
        // when this method is called, Photon will try to find us a room to join
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnEnterButtonClicked_Outdoor() {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType} };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    public void OnEnterButtonClicked_School() {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType} };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    #endregion

    #region Photon Callback Methods

    //this method will be called when user failed to join a random room
    public override void OnJoinRandomFailed(short returnCode, string message) {
        //base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }
    // this will be created when a room is created
    public override void OnCreatedRoom() {
        Debug.Log("A room is created with the name: " + PhotonNetwork.CurrentRoom.Name);
    }
    //This will be called when a local player joins the room
    public override void OnJoinedRoom() {
        Debug.Log("The Local player " + PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);


        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY)) {
            object mapType;
            if(PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.MAP_TYPE_KEY, out mapType)) {
                Debug.Log("Joined room with the map: " + (string)mapType);
            }
        }
    }
    //This will be called when someone outside of local has joined the room
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log("Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion


    #region Private Methods
    //try to create a room when there is no room to join
    private void CreateAndJoinRoom() {
        string randomRoomName = "Room_" + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        string[] roomPropsInLobby = {MultiplayerVRConstants.MAP_TYPE_KEY};
        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType} };
        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby; // this will set the room property that will be shown in the lobby
        roomOptions.CustomRoomProperties = customRoomProperties;//set properties for our room
        //This will create a room with a name and a room options
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion
}
