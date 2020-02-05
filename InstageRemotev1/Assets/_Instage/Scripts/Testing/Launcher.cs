using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
//PUN libraries
using Photon.Pun;
using Photon.Realtime;




public class Launcher : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //private GameObject controlPanel;

    [SerializeField]
    private Text feedbackText;

    [SerializeField]
    private byte maxPlayersPerRoom = 2;

    bool isConnecting;

    string gameVersion = "1";

    [Header("Player Variables")]
    [SerializeField]
    private GameObject createRoomButton;
    [SerializeField]
    private GameObject LaunchRoomButton;
    [SerializeField]
    private InputField playerNameInput;
    [SerializeField]
    private InputField roomNameInput;
    [Space(5)]
    public Text playerStatus;
    public Text connectionStatus;
    public Text Region;

    string playerName = "";
    string roomName = "";

    [SerializeField]
    Text currentRoom;
    [SerializeField]
    Text currentUser;

    //RoomCustomProperties
   


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("Connecting to Nextwork");
        LaunchRoomButton.SetActive(false);
        currentRoom.gameObject.SetActive(false);
        currentUser.gameObject.SetActive(false);
        ConnectToPhoton();
        
    }
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void ConnectToPhoton()
    {
        connectionStatus.text = "Connecting..";
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }


    public void joinRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            Debug.Log("Photon connected|trying to join room" + roomNameInput.text);

            RoomOptions roomOptions = new RoomOptions();
            //CustomProperties hashtablesetup
            ExitGames.Client.Photon.Hashtable RoomCustomProperties = new ExitGames.Client.Photon.Hashtable();

            //Custom room properties are private until set in custom room props for lobby
            RoomCustomProperties.Add("player", "john smith");
            RoomCustomProperties.Add(RoomPropety.Scenario, "FreestyleAuditorium");
            RoomCustomProperties.Add(RoomPropety.Company, "Instage");
            RoomCustomProperties.Add(RoomPropety.Location, "somewhere");

            //This chooses what custom room properties are public values
            roomOptions.CustomRoomProperties = RoomCustomProperties;

            string[] publicProperties =
            {
               RoomPropety.Scenario,
               RoomPropety.Company,
               RoomPropety.Location
            };

            roomOptions.CustomRoomPropertiesForLobby = publicProperties;
           
            

            //TypedLobby typedLobby = new TypedLobby(roomName, LobbyType.Default);
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default );
            

            //Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("player").ToString());
        }
    }

    public void loadAreana()
    {
      
            PhotonNetwork.LoadLevel(1);
    }

    
    //Photon callback Method
    public override void OnConnected()
    {
        base.OnConnected();

        connectionStatus.text = "connected to Photon";
        connectionStatus.color = Color.green;
        LaunchRoomButton.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        isConnecting = false;
        //controlPanel.SetActive(true);
        Debug.LogError("Disconnected.Something is wrong");
    }

    public override void OnJoinedRoom()
    {
       
        if (PhotonNetwork.IsMasterClient)
        {
            LaunchRoomButton.SetActive(true);
            createRoomButton.SetActive(false);
            playerStatus.text = "You are the leader";
        }

        else
        {
            createRoomButton.SetActive(false);
            playerStatus.text = "connected to lobby";
        }
        //sets feedback text
        currentRoom.gameObject.SetActive(true);
        currentRoom.text = roomName;

        currentUser.gameObject.SetActive(true);
        currentUser.text = playerName;

        playerNameInput.gameObject.SetActive(false);
        roomNameInput.gameObject.SetActive(false);

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("I AM ON THE MASTER");

        PhotonNetwork.JoinLobby();
        Debug.Log(PhotonNetwork.CloudRegion);
        Region.text = PhotonNetwork.CloudRegion;
    }




    //Takes the text from text feilds and sets the right variables
    public void SetPlayerName()
    {
        playerName = playerNameInput.text;
    }

    public void SetRoomName()
    {
        roomName = roomNameInput.text;
    }


}
