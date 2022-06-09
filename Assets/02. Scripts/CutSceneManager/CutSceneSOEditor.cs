using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System;

[CustomEditor(typeof(CutSceneSO))]
public class CutSceneSOEditor : Editor
{
    string actionInfo = "";
    int selectCharacter;
    ECutSceneAction actionType;
    public enum ECutSceneAction
    { None, CharacterMove, }

    private CutSceneAction cutSceneAction;
    // OnInspector GUI
    public override void OnInspectorGUI() //2
    {
        base.DrawDefaultInspector();
        GUILayout.Space(20);

        GUILayout.BeginVertical("Action", "window");

        actionType = (ECutSceneAction)EditorGUILayout.EnumPopup("Action", actionType);


        if (actionType != ECutSceneAction.None)
        {
            GUILayout.BeginVertical("CharacterMove", "window");

            actionInfo = EditorGUILayout.TextField( "ActionInfo", actionInfo);

            if (cutSceneAction == null)
            {
                cutSceneAction = new CutSceneAction();
            }

            Character[] characters = ((CutSceneSO)target).characterList.ToArray();
            List<string> characterList = new List<string>();
            characterList.Add("None");
            foreach (var character in characters)
            {
                characterList.Add(character.name);
            }

            selectCharacter = EditorGUILayout.Popup("Character", selectCharacter, characterList.ToArray());

            if (selectCharacter != 0)
            {
                cutSceneAction.targetCharacter = ((CutSceneSO)target).characterList[selectCharacter - 1];
            }

            cutSceneAction.nextActionDelay = EditorGUILayout.Slider("NextActionDelay", cutSceneAction.nextActionDelay, 0f, 10f);
            switch (actionType)
            {
                case ECutSceneAction.CharacterMove:

                    CharacterMove moveAction = cutSceneAction as CharacterMove;

                    if (moveAction == null)
                    {
                        moveAction = new CharacterMove();

                        moveAction.targetCharacter = cutSceneAction.targetCharacter;
                        moveAction.nextActionDelay = cutSceneAction.nextActionDelay;
                    }


                    moveAction.reachPos = EditorGUILayout.Vector2Field("ReachPos", moveAction.reachPos);
                    moveAction.moveSpeed = EditorGUILayout.FloatField("Speed", moveAction.moveSpeed);
                    GUILayout.EndVertical();

                    break;
            }

        }

        GUILayout.EndVertical();
        if (GUILayout.Button("Add"))
        {
            if (cutSceneAction != null && actionInfo == "")
            {
                ((CutSceneSO)target).cutSceneActionList.Add(cutSceneAction);
                cutSceneAction = null;
                actionType = ECutSceneAction.None;
                selectCharacter = 0;
                actionInfo = "";
            }
        }
    }
}

