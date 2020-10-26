using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string name;
    public int sceneIndex;
    public int maxPlayers;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<DefaultRoom> defaultRooms;
    public GameObject roomUI;
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server... ");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server... ");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined Lobby...");
        roomUI.SetActive(true);
    }
    public void InitaliseRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];
        //Load Scene
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);
        //Create the room
        RoomOptions roomOprions = new RoomOptions();
        roomOprions.MaxPlayers = (byte)roomSettings.maxPlayers;
        roomOprions.IsVisible = true;
        roomOprions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom(roomSettings.name, roomOprions, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room... ");
        base.OnJoinedRoom();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("New Player Joined Room...");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
