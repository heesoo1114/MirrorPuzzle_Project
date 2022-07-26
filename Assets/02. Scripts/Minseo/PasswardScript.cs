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


    private bool Check;

    private void Awake()
    {
        Check = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !Check)
        {
            password_Img.gameObject.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        password_Img.gameObject.SetActive(false);
    }
    public void EnterClick()
    {
        if (pswdInput.text == "chips" || pswdInput.text == "CHIPS")
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
        yield return new WaitForSeconds(1.0f);
        Check = true;
        text.text = "������ �Է��ϼ���";
        password_Obj.gameObject.SetActive(false);
    }

    IEnumerator NotAnswer()
    {
        text.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        text.color = Color.white;
        Check = true;
        text.text = "������ �Է��ϼ���";
    }
}
