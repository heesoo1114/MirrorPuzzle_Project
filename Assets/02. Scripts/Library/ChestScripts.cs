using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScripts : MonoBehaviour
{
    [SerializeField]
    private Image passWord;
    [SerializeField]
    private InputField chestInput;

    [SerializeField]
    private Text toggleText;

    [SerializeField]
    private GameObject chestImage;
    [SerializeField]
    private Image hintImage;

    private bool answerCheck;

    void Awake()
    {
        answerCheck = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !answerCheck)
        {
            passWord.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        passWord.gameObject.SetActive(false);
    }


    public void EnterClick()
    {
        if (chestInput.text == "A 도장" || chestInput.text == "a 도장" )
        {
            StartCoroutine("CorrectAnswer");
        }
        else
        {
            StartCoroutine("NotCorrectAnswer");
        }
    }
    IEnumerator CorrectAnswer()
    {
        toggleText.color = Color.cyan;
        toggleText.text = "정답입니다.";
        yield return new WaitForSeconds(1.0f);
        answerCheck = true;
        toggleText.color = Color.white;
        toggleText.text = "정답을 입력하세요.";

        chestImage.SetActive(false);
        hintImage.gameObject.SetActive(true);
    }

    IEnumerator NotCorrectAnswer()
    {
        toggleText.color = Color.red;
        toggleText.text = "오답입니다.";
        yield return new WaitForSeconds(1.0f);
        toggleText.color = Color.white;
        toggleText.text = "정답을 입력하세요.";
    }
}
