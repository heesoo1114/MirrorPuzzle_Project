using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CutSceneLine
{
    public string name;

    [TextArea(0, 5)]
    public string lineText;
}

[System.Serializable]
public class CutSceneScript
{
    public List<CutSceneLine> cutSceneLineList;

    public int Count => cutSceneLineList.Count;

    public CutSceneLine this[int idx]
    {
        get => cutSceneLineList[idx];
    }
}

[CreateAssetMenu(menuName ="SO/CutScene")]
public class CutSceneSO : ScriptableObject
{
    public string cutSceneID;
    public List<CutSceneScript> cutSceneScriptList;
    public int Count => cutSceneScriptList.Count;

    public CutSceneScript this[int idx]
    {
        get => cutSceneScriptList[idx];
    }
}
