using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DEBUGAutoJoin : MonoBehaviourPunCallbacks
{
    //THIS IS A DEBUG SCRIPT TO MAKE TESTING REMOTE FEATURES FASTER


    // Start is called before the first frame update
    void Start()
    {
        ConnectToPhoton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ConnectToPhoton()
    {
        //connectionStatus.text = "Connecting..";
        Debug.Log("connecting to pun");
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();



    }
    //Room creation/joining
    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
           
            //Debug.Log("Photon connected|trying to join room" + roomNameInput.text);

            RoomOptions roomOptions = new RoomOptions();
            //CustomProperties hashtablesetup
            

            //Custom room properties are private until set in custom room props for lobby
    

            //TypedLobby typedLobby = new TypedLobby(roomName, LobbyType.Default);
            PhotonNetwork.JoinOrCreateRoom("TEST", roomOptions, TypedLobby.Default);


      
        }
    }







    //Overrides
    public override void OnConnectedToMaster()
    {
        Debug.Log("I AM ON THE MASTER");
        PhotonNetwork.JoinLobby();

        Debug.Log(PhotonNetwork.CloudRegion);
    }

    public override void OnConnected()
    {
        base.OnConnected();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        CreateRoom();
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("created a room!!!");
        
       

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("RoomJoined");
        base.OnJoinedRoom();
    }
}
