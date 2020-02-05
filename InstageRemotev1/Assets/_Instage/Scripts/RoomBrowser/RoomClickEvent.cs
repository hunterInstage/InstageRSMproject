using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomClickEvent : MonoBehaviour
{
    Button RoomButton;
    

    // Start is called before the first frame update
    void Start()
    {
        RoomButton = GetComponent<Button>();
        RoomButton.onClick.AddListener(SendRoomInfo);
    }

    public void SendRoomInfo()
    {
        FillRoomInfo RI = GetComponent<FillRoomInfo>();
        FindObjectOfType<JoinSelectedRoom>().SetSelectedInfo(RI.info.Name, RI.info);
    }



}
