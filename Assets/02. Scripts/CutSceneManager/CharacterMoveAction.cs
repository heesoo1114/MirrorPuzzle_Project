using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterMoveAction : CutSceneAction
{
    public Vector2 startPos;
    public bool isStart;
    public Vector2 reachPos;
    public float moveSpeed;

    public override void TakeAction(Character character)
    {
        if(isStart)
        {
            character.transform.position = startPos;
        }
        float distance = Vector2.Distance(character.transform.position, reachPos);

        float duration = distance / moveSpeed;

        character.Move(reachPos, duration, DG.Tweening.Ease.Linear);
    }
}
