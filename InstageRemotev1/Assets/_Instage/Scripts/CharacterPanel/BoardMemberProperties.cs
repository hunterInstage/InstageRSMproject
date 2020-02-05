using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//A container to reference for board member info in other references
[System.Serializable]
public class BoardMemberProperties
{
    public string BoardMemberName;
    public Sprite Portrait;
    
}

[System.Serializable]
public class BoardMembers
{
    public BoardMemberProperties William;
    public BoardMemberProperties Anita;
    public BoardMemberProperties George;
    public BoardMemberProperties Susan;
    public BoardMemberProperties Chandi;
    public BoardMemberProperties David;
    public BoardMemberProperties Jennifer;
    public BoardMemberProperties Joan;
    public BoardMemberProperties Jason;
    public BoardMemberProperties Mark;

}
public class MemberList
{
    public enum CharacterList {william,Anita,George,Susan,Chandi,David,Jennifer,Joan,Jason,Mark};
}
