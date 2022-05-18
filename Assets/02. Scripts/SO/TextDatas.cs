using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextData
{
    public string dataID;

    [TextArea(3,7)]
    public string text;
}


[CreateAssetMenu(menuName = "SO/TextDatas")]
public class TextDatas : ScriptableObject
{
    public string ID;
    [SerializeField] private List<TextData> _textDataList;

    public string FindTextData(string ID)
    {
        string value = "";

        foreach(TextData td in _textDataList)
        {
            if(td.dataID.CompareTo(ID) == 0)
            {
                value = td.text;
                break;
            }
        }

        return value;
    }
}
