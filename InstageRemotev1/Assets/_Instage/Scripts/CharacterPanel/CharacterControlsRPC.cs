using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;


public class CharacterControlsRPC : MonoBehaviour
{
    
    PhotonView SequenceView;
    
    int previouse = -1;

    // Start is called before the first frame update
    void Start()
    {
        SequenceView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


 //------------ Utility---------------------------------------


//--------------------------------------------------------------


//For characater face buttons
    public void TRIGSetupPortraitsUp(int oi)
    {
        SequenceView.RPC("SetPortraitsUp", RpcTarget.Others, oi);
    }

    public void TRIGCharacterPressed(int bi)
    {
        SequenceView.RPC("CharacterPressed", RpcTarget.Others, bi,previouse);

        previouse = bi;
    }


//For character nod bar and actions
    public void TRIGClickNodButton(int nod)
    {
        SequenceView.RPC("ClickNodButton", RpcTarget.Others, nod);
    }

    public void TRIGClickActionButton(int action)
    {
        SequenceView.RPC("ClickActionButton", RpcTarget.Others, action);
    }

      


    #region ------------CHARACTER FACE BUTTON RPC CALLS----------------------
    [PunRPC]
    public void SetPortraitsUp(int owner)
    {
        FindObjectOfType<CharacterButtonReference>().CharButtons[owner].SetActive(false);
    }
    [PunRPC]
    public void CharacterPressed(int buttonindex)
    {
        //here so RPC is happy
    }
    #endregion

    [PunRPC]
    public void LookingAtHighlight(int face, bool red)
    {

        Image facebtn = FindObjectOfType<CharacterButtonReference>().CharButtons[face].GetComponent<Image>();

        if (red)
        {
            facebtn.color = FindObjectOfType<CharacterButtonReference>().Facehighlight;
        }

        else
        {
            facebtn.color = FindObjectOfType<CharacterButtonReference>().NormalState;
        }

    }















    [PunRPC]
    public void ClickNodButton(int nod)
    {

    }

    [PunRPC]
    public void ClickActionButton(int action)
    {

    }



}
