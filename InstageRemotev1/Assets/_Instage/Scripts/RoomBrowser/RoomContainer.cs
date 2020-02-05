using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class RoomContainer : MonoBehaviourPunCallbacks
{
    public List<RoomInfo> CurrentRooms;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList.Count > 0)
        {
            Debug.Log(roomList[0].Name);
            CurrentRooms = roomList;

            if (FindObjectOfType<ListRooms>())
            {
                FindObjectOfType<ListRooms>().CreateRoomButtons(CurrentRooms);
            }
        }

      

    }

}
