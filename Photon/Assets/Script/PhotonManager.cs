using UnityEngine;
using System.Collections;
using System;

public class PhotonManager : MonoBehaviour {
	
	public GameObject avatar;

	void Start () {
        PhotonNetwork.ConnectUsingSettings("TanksPUN_v1.0");
		var tmp = PhotonVoiceNetwork.Client;
    }

	public virtual void OnConnectedToMaster()
	{
		Debug.Log("OnConnectedToMaster");
		PhotonNetwork.JoinRandomRoom();
	}

	public virtual void OnJoinedLobby()
	{
		Debug.Log("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}

	public virtual void OnPhotonRandomJoinFailed()
	{
		Debug.Log("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom(null, new RoomOptions(){MaxPlayers = 4}, null);
	}

	public virtual void OnfailedToConnectToPhoton(DisconnectCause cause)
	{
		Debug.LogError(cause);
	}

	public void OnJoinedRoom()
	{
		Debug.Log("OnJoinedRoom");
		GameObject go = PhotonNetwork.Instantiate(avatar.name, Vector3.zero, Quaternion.identity, 0);
	}

}