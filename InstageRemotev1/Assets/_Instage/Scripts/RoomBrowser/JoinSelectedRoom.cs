using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class JoinSelectedRoom : MonoBehaviourPunCallbacks
{
    [System.Serializable]
    public class SelectedRoom{
       public string RoomName;
       public RoomInfo SelectedInfo;

    }

    public SelectedRoom SelectedRoomInfo;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Set selected room info

    public void SetSelectedInfo(string name, RoomInfo ri)
    {
        SelectedRoomInfo.RoomName = name;
        SelectedRoomInfo.SelectedInfo = ri;
    }

    public void JoinSession()
    {
        PhotonNetwork.JoinRoom(SelectedRoomInfo.RoomName);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("joinedSession!!!");
    }
}
