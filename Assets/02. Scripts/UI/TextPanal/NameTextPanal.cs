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
    }
}
