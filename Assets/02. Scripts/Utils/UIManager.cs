using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    public Image letterImage;
    public Image keypad;
    private const string password = "1357";
    private string currentPw = "";

    public void SetActiveLetter(bool isActive)
    {
        letterImage.gameObject.SetActive(isActive);
        letterImage.transform.localScale = Vector3.zero;
        letterImage.transform.DOScale(1f,0.3f);
    }

    public void SetActiveLocker(bool isActive)
    {
        keypad.gameObject.SetActive(isActive);
    }

    private void CheckPassword()
    {
        if(password == currentPw)
        {
            Debug.Log("맞음");
        }
        else
        {
            Debug.Log("틀림");
        }
    }

    public void InputPassword(string number)
    {
        currentPw += number;
        if (currentPw.Length == 4)
        {
            CheckPassword();
            currentPw = "";
        }
    }


}
