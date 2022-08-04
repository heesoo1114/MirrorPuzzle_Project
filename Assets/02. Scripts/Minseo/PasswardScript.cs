    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswardScript : MonoBehaviour
{
    [SerializeField] 
    private InputField pswdInput;
    [SerializeField] 
    private Text text;
    [SerializeField] 
    private Image password_Img;
    [SerializeField] 
    private GameObject password_Obj;


    private bool Check = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !Check)
        {
            GameManager.Inst.ChangeGameState(EGameState.UI);
            password_Obj.SetActive(true);
        }
    }
    public void EnterClick()
    {
        if (pswdInput.text == "chips" || pswdInput.text == "CHIPS" || pswdInput.text == "Chips")
        {
            StartCoroutine("Answer");
        }
        else
        {
            StartCoroutine("NotAnswer");
        }
    }
    IEnumerator Answer()
    {
        text.text = "정답입니다!";
        yield return new WaitForSeconds(1.0f);
        password_Obj.gameObject.SetActive(false);
        Check = true;
        InventorySystem.Inst.AddItem("BBROOMKEY");
        GameManager.Inst.ChangeGameState(EGameState.Game);
        gameObject.SetActive(false);

    }

    IEnumerator NotAnswer()
    {
        text.text = "오답입니다";
        text.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        text.color = Color.white;
        Check = true;
        text.text = "정답을 입력하세요";
    }
}
