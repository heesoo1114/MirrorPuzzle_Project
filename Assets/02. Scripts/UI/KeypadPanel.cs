using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadPanel : MonoBehaviour
{
    private string number;
    private Text numberText;
    private Button button;

    private GameManager gameManager;

    private void Start()
    {
        numberText = GetComponentInChildren<Text>();
        number = (transform.GetSiblingIndex() + 1).ToString();
        numberText.text = number;

        button = GetComponent<Button>();
        button.onClick.AddListener(InputButton);

        gameManager = FindObjectOfType<GameManager>();
    }

    private void InputButton()
    {
        if(gameManager.UI.isInputKey == false)
        {
            return;
        }
        gameManager.UI.InputPassword(number);
    }

}
