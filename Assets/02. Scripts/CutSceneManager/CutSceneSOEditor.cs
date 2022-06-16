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
            GUILayout.Space(10);
            GUILayout.BeginVertical(actionType.ToString(), "window");
            GUILayout.Space(10);


            actionInfo = EditorGUILayout.TextField( "ActionInfo", actionInfo);

            if (cutSceneAction == null)
            {
                cutSceneAction = new CutSceneAction();
            }

            SelectCutSceneType();

            SelectTargetCharacter();

            SelectNextDelay();

            switch (actionType)
            {
                case ECutSceneAction.CharacterMoveAction:
                    FormCharcterMoveAction();
                    break;

                case ECutSceneAction.CharacterTalkAction:
                    FormChacterTalkAction();
                    break;
            }
            GUILayout.EndVertical();

        }

        GUILayout.EndVertical();

        if (GUILayout.Button("Add"))
        {
            if (cutSceneAction != null && actionInfo != "")
            {
                ((CutSceneSO)target).cutSceneActionList.Add(cutSceneAction);
                cutSceneAction = null;
                actionType = ECutSceneAction.None;
                selectCharacter = 0;
                actionInfo = "";
            }
        }
    }

    public void SelectCutSceneType()
    {
        cutSceneAction.actionPlayType = (ECutScenePlayType)EditorGUILayout.EnumPopup("PlayType", cutSceneAction.actionPlayType);
    }

    public void SelectTargetCharacter()
    {
        CharacterData[] characters = ((CutSceneSO)target).characterList.ToArray();
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
    }

    public void SelectNextDelay()
    {
        cutSceneAction.nextActionDelay = EditorGUILayout.Slider("NextActionDelay", cutSceneAction.nextActionDelay, 0f, 10f);
    }

    public void FormCharcterMoveAction()
    {
        CharacterMoveAction moveAction = cutSceneAction as CharacterMoveAction;

        if (moveAction == null)
        {
            moveAction = new CharacterMoveAction();

            moveAction.targetCharacter = cutSceneAction.targetCharacter;
            moveAction.nextActionDelay = cutSceneAction.nextActionDelay;
        }


        moveAction.reachPos = EditorGUILayout.Vector2Field("ReachPos", moveAction.reachPos);
        moveAction.moveSpeed = EditorGUILayout.FloatField("Speed", moveAction.moveSpeed);

    }

    public void FormChacterTalkAction()
    {
        CharacterTalkAction talkAction = cutSceneAction as CharacterTalkAction;

        if (talkAction == null)
        {
            talkAction = new CharacterTalkAction();

            talkAction.targetCharacter = cutSceneAction.targetCharacter;
            talkAction.nextActionDelay = cutSceneAction.nextActionDelay;
        }


        talkAction.scriptText = EditorGUILayout.TextField("ScriptText", talkAction.scriptText, GUILayout.Height(70));

    }
}


