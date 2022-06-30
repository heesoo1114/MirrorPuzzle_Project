using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScripts : InteractionObject
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

    void Start()
    {
        answerCheck = false;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && answerCheck)
            hintImage.gameObject.SetActive(false);
    }

    public override void InteractionEvent()
    {
        if(!answerCheck)
        {
            GameManager.Inst.SetGameState(true);
            passWord.gameObject.SetActive(true);
        }
    }

    public override void ExitInteraction()
    {
        GameManager.Inst.SetGameState(false);
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

        answerCheck = true;
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
