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
            GameManager.Inst.gameState = EGameState.Game;
        }
    }

    public override void InteractionEvent()
    {
        if(!answerCheck)
        {
<<<<<<< HEAD:Assets/02. Scripts/Yujin/Libray/ChestScripts.cs
            GameManager.Inst.gameState = EGameState.UI;
=======
        GameManager.Inst.ChangeGameState(EGameState.UI);

>>>>>>> OIF:Assets/02. Scripts/Library/ChestScripts.cs
            passWord.gameObject.SetActive(true);
        }
    }

    public override void ExitInteraction()
    {
<<<<<<< HEAD:Assets/02. Scripts/Yujin/Libray/ChestScripts.cs
        GameManager.Inst.gameState = EGameState.Game;
=======
        GameManager.Inst.ChangeGameState(EGameState.Game);

>>>>>>> OIF:Assets/02. Scripts/Library/ChestScripts.cs
        passWord.gameObject.SetActive(false);
    }

    public void EnterClick()
    {
        if (chestInput.text == "A 도장" || chestInput.text == "a 도장" )
        {
            Debug.Log("정답");
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
        
        answerChestSound?.Invoke();

        yield return new WaitForSeconds(1.0f);
        
        answerCheck = true;
        toggleText.color = Color.white;
        toggleText.text = "정답을 입력하세요.";

        chestImage.SetActive(false);
        hintImage.gameObject.SetActive(true);

        GameManager.Inst.librayChestPuzzleClear = true;
        answerCheck = true;
        GameManager.Inst.gameState = EGameState.Game;
    }

    IEnumerator NotCorrectAnswer()
    {
        toggleText.color = Color.red;
        toggleText.text = "오답입니다.";

        notAnswerChestSound?.Invoke();

        yield return new WaitForSeconds(1.0f);
        
        toggleText.color = Color.white;
        toggleText.text = "정답을 입력하세요.";
    }

    public void OutChest()
    {
        passWord.gameObject.SetActive(false);
        GameManager.Inst.gameState = EGameState.Game;
    }
}
