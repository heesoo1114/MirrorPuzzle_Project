using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{
    public Image pwLetterImage;
    public Image letterImage;
    private Text letterText;
    public Image keypad;
    private const string PASSWORD = "85672";
    private string currentPw = "";

    [SerializeField]
    private GameObject key;
    [SerializeField] private Text pwText;
    [HideInInspector]
    public bool isInputKey = true;

    [SerializeField] private Image changeImage;

    private void Start()
    {
        letterText = letterImage.transform.GetChild(0).GetComponent<Text>();
    }

    public void SetActivePwLetter(bool isActive)
    {
        pwLetterImage.gameObject.SetActive(isActive);
        pwLetterImage.transform.localScale = Vector3.zero;
        pwLetterImage.transform.DOScale(1f, 0.3f);
    }

    public void SetActiveLetter(string letter = "")
    {
        bool isActive;

        if (letter.Length > 0)
            isActive = true;
        else
            isActive = false;

        letterImage.gameObject.SetActive(isActive);
        letterImage.transform.localScale = Vector3.zero;
        letterImage.transform.DOScale(1f, 0.3f);

        letterText.text = letter;
    }


    public void SetActiveLocker(bool isActive)
    {
        keypad.gameObject.SetActive(isActive);
    }

    private void CheckPassword()
    {
        if (PASSWORD == currentPw)
        {
            keypad.gameObject.SetActive(false);
            key.gameObject.SetActive(true);
        }
        else
        {
            keypad.transform.GetChild(0).DOShakePosition(0.5f, 20);
        }
    }

    public void InputPassword(string number)
    {
        currentPw += number;
        pwText.text = currentPw;
        if (currentPw.Length == PASSWORD.Length)
        {
            CheckPassword();
            currentPw = "";
            StartCoroutine(ResetPw());
        }
    }
    IEnumerator ResetPw()
    {
        isInputKey = false;
        yield return new WaitForSeconds(1f);
        pwText.text = currentPw;
        isInputKey = true;
    }

    public void ChangeRoom(Action loadRoom)
    {
        loadRoom.Invoke();
    }
}