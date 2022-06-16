using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CharacterData
{
    public string name;
    public RuntimeAnimatorController animatorCtrl;
    public Color color;
}




[CreateAssetMenu(menuName = "SO/CutSceneSO")]
public class CutSceneSO : ScriptableObject
{
    public string cutSceneID;
    public List<CharacterData> characterList;
    public List<CutSceneAction> cutSceneActionList;

}
