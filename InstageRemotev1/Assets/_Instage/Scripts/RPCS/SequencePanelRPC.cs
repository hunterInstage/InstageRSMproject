using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;


public class SequencePanelRPC : MonoBehaviour
{
    PhotonView SequenceView;


    [SerializeField]
    public Button[] CurrentSequenceButtons;



    // Start is called before the first frame update
    void Start()
    {
        SequenceView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //--------------------Methods that will trigger the below Actual Rpc Methods--------
    public void TRIGSequenceButtonPressed(int BTN)
    {
        SequenceView.RPC("buttonpressed", RpcTarget.Others, BTN);
    }







    //--------------------ACTUAL RPC METHODS------------------------------------
    //Will Fire Click events on corresponding Butoon
    [PunRPC]
    public void buttonpressed(int Button)
    {
        if (CurrentSequenceButtons != null)
        {
            CurrentSequenceButtons[Button].onClick.Invoke();
        }
        Debug.Log(" the remote user clicked the button");
       
    }

    [PunRPC]
    //Turns on and off UI elements based on whats happening in speakers scene
    public void SetSequencenUI(int part)
    {
        if (FindObjectOfType<SequencePanelToggler>())
        {
            FindObjectOfType<SequencePanelToggler>().TurnOnPanel(part);
        }
        Debug.Log("trying to toggle panel");
    }

    [PunRPC]
    public void TurnOffSequenceUI(int p)
    {
        if (FindObjectOfType<SequencePanelToggler>())
        {
            FindObjectOfType<SequencePanelToggler>().TurnOffPanel(p);
        }
    }


}
