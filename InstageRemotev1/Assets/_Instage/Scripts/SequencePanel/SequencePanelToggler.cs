using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePanelToggler : MonoBehaviour
{
    [SerializeField]
    public GameObject[] SequencePanels;


    // Start is called before the first frame update
    public void TurnOnPanel(int panel)
    {

        SequencePanels[panel].SetActive(true);

        if (panel!=0){

            SequencePanels[panel - 1].SetActive(false);
        }
        
    }

    public void TurnOffPanel(int PAN)
    {
        SequencePanels[PAN].SetActive(false);
    }
}
