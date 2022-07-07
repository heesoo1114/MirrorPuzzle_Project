using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswardScript : MonoBehaviour
{
    [SerializeField] private InputField pswdInput;
    [SerializeField] private Text text;
    [SerializeField] private Image password;

    private bool Check;

    private void Awake()
    {
        Check = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !Check)
        {
            password.gameObject.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        password.gameObject.SetActive(false);
    }
    public void EnterClick()
    {
        if (pswdInput.text == "chips" || pswdInput.text == "CHIPS")
        {
            StartCoroutine("Answer");
        }
        else
        {
            StartCoroutine("WronAnswer");
        }
    }
    IEnumerator Answer()
    {
        text.text = "�����Դϴ�";
        yield return new WaitForSeconds(1.0f);
        Check = true;
        text.text = "������ �Է��ϼ���";
    }

    IEnumerator NotAnswer()
    {
        text.text = "�����Դϴ�";
        yield return new WaitForSeconds(1.0f);
        Check = true;
        text.text = "������ �Է��ϼ���";
    }
}
