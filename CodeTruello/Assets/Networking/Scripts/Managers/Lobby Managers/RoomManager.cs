using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    private string mapType;

    public TextMeshProUGUI OccupancyRateText_ForOldWest;
    public TextMeshProUGUI OccupancyRateText_ForWizard;
    public TextMeshProUGUI OccupancyRateText_ForCastle;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnectedAndReady){
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.JoinLobby();
        }
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

    //Add our maps
    public void OnEnterButtonClicked_OldWest() {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_OLDWEST;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType} };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    
    public void OnEnterButtonClicked_Wizard() {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_WIZARD;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType} };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    
    public void OnEnterButtonClicked_Castle() {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_CASTLE;
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

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to servers again.");
        PhotonNetwork.JoinLobby();
    }

    // this will be created when a room is created
    public override void OnCreatedRoom() {
        Debug.Log("A room is created with the name: " + PhotonNetwork.CurrentRoom.Name);
    }
    //This will be called when a local player joins the room
    public override void OnJoinedRoom() {
        Debug.Log("The Local player " + PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
        PlayerCount.NumberOfPlayers = 1;

        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY)) {
            object mapType;
            if(PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.MAP_TYPE_KEY, out mapType)) {
                Debug.Log("Joined room with the map: " + (string)mapType);
                if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_OLDWEST) {
                    // load the Western scene
                    PhotonNetwork.LoadLevel("WesternOldTown");
                } else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_WIZARD) {
                    // load the Wizard scene
                    PhotonNetwork.LoadLevel("WizardLair");
                } else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_CASTLE) {
                    // load the Castle scene
                    // Scene for map has to be added to the build settings
                    Debug.Log("Once map is added, will join " + (string)mapType);
                    //PhotonNetwork.LoadLevel("Castle");
                }
            }
        }
    }
    //This will be called when someone outside of local has joined the room
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log("Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
        PlayerCount.NumberOfPlayers = 2;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        if (roomList.Count == 0){
            //There is no room at all
            OccupancyRateText_ForOldWest.text = "Players: " + 0 + " / " + 2;
            OccupancyRateText_ForWizard.text = "Players: " + 0 + " / " + 2;
            OccupancyRateText_ForCastle.text = "Players: " + 0 + " / " + 2;
        }
        foreach(RoomInfo room in roomList){
            Debug.Log(room.Name);
            if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_OLDWEST)){
                //Update the Old West room occupancy field
                Debug.Log("Room is an Old West Map. Player count is: " + room.PlayerCount);
                OccupancyRateText_ForOldWest.text = "Players: " + room.PlayerCount + " / " + 2;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_WIZARD)){
                Debug.Log("Room is a Wizard map. Player count is: " + room.PlayerCount);
                OccupancyRateText_ForWizard.text = "Players: " + room.PlayerCount + " / " + 2;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_CASTLE)){
                Debug.Log("Room is a Castle Map. Player count is: " + room.PlayerCount);
                OccupancyRateText_ForCastle.text = "Players: " + room.PlayerCount + " / " + 2;
            }
        }
    }

    public override void OnJoinedLobby(){
        Debug.Log("Joined the Lobby.");
    }

    #endregion


    #region Private Methods
    //try to create a room when there is no room to join
    private void CreateAndJoinRoom() {
        string randomRoomName = "Room_" + mapType + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        string[] roomPropsInLobby = {MultiplayerVRConstants.MAP_TYPE_KEY};
        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType} };
        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby; // this will set the room property that will be shown in the lobby
        roomOptions.CustomRoomProperties = customRoomProperties;//set properties for our room
        //This will create a room with a name and a room options
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion
}
