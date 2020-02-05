using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUIToDefault : MonoBehaviour
{
    [Header("Turn This on to have starting ui state")]
    [SerializeField]
    bool SetToDefaultState = true;
    [Space(10)]
    [SerializeField]
    GameObject[] UIToLeaveOn;
  
   
    bool LeaveOn=false;
    // Start is called before the first frame update
    void Start()
    {
        if (SetToDefaultState)
        {
            SetDefaultUI();
        }
    }

 
    public void SetDefaultUI()
    {
       

        Canvas[] CanvaseObjects = GetComponentsInChildren<Canvas>();
        // Turn off all canvas obects that is a child of the master
        
        for (int i = 0; i < CanvaseObjects.Length; i++)
        {
        var Screen = CanvaseObjects[i].gameObject;


        //Check if needs to be left on
            for (int o = 0; o < UIToLeaveOn.Length; o++)
            {
                var screenToLeave = UIToLeaveOn[o].gameObject;
                if (Screen == screenToLeave|| Screen==gameObject)
                {
                LeaveOn = true;
                }
                screenToLeave.SetActive(true);
            }

            if (LeaveOn)
               {
                Debug.Log("leave on");
                LeaveOn = false;
                
               }

            else
            {
                Screen.SetActive(false);
            }

        }
        
    }
}
