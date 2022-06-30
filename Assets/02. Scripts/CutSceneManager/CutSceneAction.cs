using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECutScenePlayType
{
    Append,
    Join
}

[System.Serializable]
public  class CutSceneAction
{
    [TextArea] public string actionInfo;
    public ECutScenePlayType actionPlayType;
    public CharacterData targetCharacter;
    public float nextActionDelay;

    public virtual void TakeAction(Character character) { }
}
