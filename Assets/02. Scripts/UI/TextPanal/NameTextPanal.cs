using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTextPanal : MonoBehaviour
{
    [SerializeField] private Text _nameText;

    public void ChangeNameText(string name)
    {
        _nameText.text = name;
        if (name == "루카스")
            _nameText.color = new Color(0.7686274509803922f, 0.4666666666666667f, 0.3490196078431373f);
        else if (name == "올리버")
            _nameText.color = new Color(0, 0.6588235294117647f, 0);
        else
            _nameText.color = new Color(1, 1, 1);
    }
}
