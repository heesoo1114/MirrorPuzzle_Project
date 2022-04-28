using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    public Image letterImage;
    public Image keypad;
    private const string PASSWORD = "85672";
    private string currentPw = "";
    [SerializeField]
    private GameObject key;


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
        if(PASSWORD == currentPw)
        {
            keypad.gameObject.SetActive(false);
            key.gameObject.SetActive(true);
        }
        else
        {
            keypad.transform.GetChild(0).DOShakePosition(0.5f,20);
                
        }
    }

    public void InputPassword(string number)
    {
        currentPw += number;
        if (currentPw.Length == PASSWORD.Length)
        {
            CheckPassword();
            currentPw = "";
        }
    }


}
