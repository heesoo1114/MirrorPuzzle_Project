using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChestScripts : InteractionObject
{
    public UnityEvent answerChestSound;
    public UnityEvent notAnswerChestSound;

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
        {
            hintImage.gameObject.SetActive(false);
            GameManager.Inst.ChangeGameState(EGameState.Game);
        }
    }

    public override void InteractionEvent()
    {
        if(!answerCheck)
        {
        GameManager.Inst.ChangeGameState(EGameState.UI);
            passWord.gameObject.SetActive(true);
        }
    }

    public override void ExitInteraction()
    {
        GameManager.Inst.ChangeGameState(EGameState.Game);
        passWord.gameObject.SetActive(false);
    }

    public void EnterClick()
    {
        if (chestInput.text == "A ����" || chestInput.text == "a ����" )
        {
            Debug.Log("����");
            StartCoroutine("CorrectAnswer");
        }
        else
        {
            StartCoroutine("NotCorrectAnswer");
        }
    }

    IEnumerator CorrectAnswer()
    {
        answerCheck = true;
        toggleText.color = Color.cyan;
        toggleText.text = "�����Դϴ�.";
        
        answerChestSound?.Invoke();

        yield return new WaitForSeconds(1.0f);
        
        toggleText.color = Color.white;
        toggleText.text = "������ �Է��ϼ���.";

        chestImage.SetActive(false);
        hintImage.gameObject.SetActive(true);

        GameManager.Inst.librayChestPuzzleClear = true;
    }

    IEnumerator NotCorrectAnswer()
    {
        toggleText.color = Color.red;
        toggleText.text = "�����Դϴ�.";

        notAnswerChestSound?.Invoke();

        yield return new WaitForSeconds(1.0f);
        
        toggleText.color = Color.white;
        toggleText.text = "������ �Է��ϼ���.";
    }

    public void OutChest()
    {
        if (answerCheck) return;

        passWord.gameObject.SetActive(false);
        GameManager.Inst.ChangeGameState(EGameState.Game);
    }
}
