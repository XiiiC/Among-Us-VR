using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server... ");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server... ");
        base.OnConnectedToMaster();
        RoomOptions roomOprions = new RoomOptions();
        roomOprions.MaxPlayers = 10;
        roomOprions.IsVisible = true;
        roomOprions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOprions, TypedLobby.Default);
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
