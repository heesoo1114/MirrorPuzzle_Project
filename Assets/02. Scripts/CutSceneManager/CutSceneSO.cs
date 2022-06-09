using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Character
{
    public string name;
    public Sprite sprite;
    public Color color;
}

[System.Serializable]
public class CharacterScript
{
    public Character character;
    public string scriptText;
}

[System.Serializable]
public class CutSceneAction
{
    [TextArea] public string actionInfo;
    public Character targetCharacter;
    public float nextActionDelay;
}

[System.Serializable]
public class CharacterMove : CutSceneAction
{
    public Vector2 reachPos;
    public float moveSpeed;
}


[CreateAssetMenu(menuName = "SO/CutSceneSO")]
public class CutSceneSO : ScriptableObject
{
    public string cutSceneID;
    public List<Character> characterList;
    public List<CutSceneAction> cutSceneActionList;

}
