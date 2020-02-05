using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ListRooms : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform Content;
    [SerializeField]
    private FillRoomInfo roomListing;


    public void Start()
    {
        if (FindObjectOfType<RoomContainer>())
        {
            foreach (RoomInfo info in FindObjectOfType<RoomContainer>().CurrentRooms)
            {
                FillRoomInfo listing = Instantiate(roomListing, Content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                   
                }
            }
        }
      
    }


    public void CreateRoomButtons(List<RoomInfo> RI)
    {
        foreach (RoomInfo info in RI)
        {
            FillRoomInfo listing = Instantiate(roomListing, Content);
            if (listing != null)
            {
                listing.SetRoomInfo(info);
               
            }
        }
    }


 

}
