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

[CreateAssetMenu(menuName ="SO/CutScene/Script")]
public class CutSceneSO : ScriptableObject
{
    public string cutSceneID;
    public List<CutSceneLine> cutSceneLineList;

    public int Count => cutSceneLineList.Count;

    public CutSceneLine this[int idx]
    {
        get => cutSceneLineList[idx];
    }
    
}
