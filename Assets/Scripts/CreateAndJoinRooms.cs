using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createRoom;
    public TMP_InputField joinRoom;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoom.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoom.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
