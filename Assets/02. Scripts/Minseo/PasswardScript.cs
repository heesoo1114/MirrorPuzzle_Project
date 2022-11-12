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

    [SerializeField]
    private GameObject key;


    private bool Check = false;
    private bool filmClear = false;

    private void Start() 
    {
        Check = (PlayerPrefs.GetInt("InteractionKeyCheck") == 1);
        filmClear = (PlayerPrefs.GetInt("InteractionKeyFilmClear") == 1);
    }

    public void FilmClear()
    {
        filmClear = true;
        PlayerPrefs.SetInt("InteractionKeyFilmClear", 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!filmClear) return;

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
        text.text = "�����Դϴ�!";
        yield return new WaitForSeconds(1.0f);
        password_Obj.gameObject.SetActive(false);
        Check = true;
        PlayerPrefs.SetInt("InteractionKeyCheck", 1);
        key.GetComponent<SmallbrotherRoomkey>().Falling(); // ���� ������
        GameManager.Inst.ChangeGameState(EGameState.Game);
        gameObject.SetActive(false);

    }

    IEnumerator NotAnswer()
    {
        text.text = "�����Դϴ�";
        text.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        text.color = Color.white;
        Check = true;
        PlayerPrefs.SetInt("InteractionKeyCheck", 1);
        text.text = "������ �Է��ϼ���";
    }
}
