using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortaitSetter : MonoBehaviour
{
    public MemberList.CharacterList List;

    public void Start()
    {
        SetPortait();
    }

   

    public void SetPortait()
    {
        BoardMembers bm = FindObjectOfType<BoardMemberContainer>().characters;

        Image Portait = GetComponent<Image>();
        
        
        switch (List)
        {
            case MemberList.CharacterList.william:
                Portait.sprite = bm.William.Portrait;
                
                break;

            case MemberList.CharacterList.Anita:
                Portait.sprite = bm.Anita.Portrait;
                break;

            case MemberList.CharacterList.George:
                Portait.sprite = bm.George.Portrait;
                break;

            case MemberList.CharacterList.Susan:
                Portait.sprite = bm.Susan.Portrait;
                break;

            case MemberList.CharacterList.Chandi:
                Portait.sprite = bm.Chandi.Portrait;
                break;

            case MemberList.CharacterList.David:
                Portait.sprite = bm.David.Portrait;
                break;

            case MemberList.CharacterList.Jennifer:
                Portait.sprite = bm.Jennifer.Portrait;
                break;

            case MemberList.CharacterList.Joan:
                Portait.sprite = bm.Joan.Portrait;
                break;

            case MemberList.CharacterList.Jason:
                Portait.sprite = bm.Jason.Portrait;
                break;

            case MemberList.CharacterList.Mark:
                Portait.sprite = bm.Mark.Portrait;
                break;
        }
    }
}
