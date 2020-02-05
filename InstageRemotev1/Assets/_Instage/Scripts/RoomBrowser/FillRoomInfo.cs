using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;

public class FillRoomInfo : MonoBehaviour
{
    //Button UI Elements
    [SerializeField]
    TextMeshProUGUI NameText;
    [SerializeField]
    TextMeshProUGUI ScenarioText;
    [SerializeField]
    TextMeshProUGUI CompanyText;
    [SerializeField]
    TextMeshProUGUI LocationText;
    [HideInInspector]
    public RoomInfo info;

    //Class containing room info
    //[SerializeField]
    //public class RoomInfo
    //{
    //    public string Name;
    //    public string Scenario;
    //    public string Company;
    //    public string Location;
    //}

    //public RoomInfo ButtonInfo;
    
    //Sets up room nutton to display information properly
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        NameText.text = roomInfo.CustomProperties[RoomPropety.Name].ToString();
        ScenarioText.text = roomInfo.CustomProperties[RoomPropety.Scenario].ToString();
        CompanyText.text = roomInfo.CustomProperties[RoomPropety.Company].ToString();
        LocationText.text = roomInfo.CustomProperties[RoomPropety.Location].ToString();
        info = roomInfo;

        Debug.Log(roomInfo.CustomProperties[RoomPropety.Name].ToString());
        
    }



}
