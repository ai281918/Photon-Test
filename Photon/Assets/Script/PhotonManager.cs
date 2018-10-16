using UnityEngine;
using System.Collections;
 
public class PhotonManager : Photon.PunBehaviour {
    public static PhotonManager instance;
 
    void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

	void Start () {
        PhotonNetwork.ConnectUsingSettings("TanksPUN_v1.0");
    }

	public void JoinGameRoom()
	{
		RoomOptions options = new RoomOptions();
		options.MaxPlayers = 4;
		PhotonNetwork.JoinOrCreateRoom("Fighting Room", options, null);
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("您已進入遊戲室!!");
		// 如果是Master Client, 即可建立/初始化,與載入遊戲場景
		if (PhotonNetwork.isMasterClient)
		{
			Debug.Log("I am master client");
			// PhotonNetwork.LoadLevel("GameRoomScene");
		}
	}
}