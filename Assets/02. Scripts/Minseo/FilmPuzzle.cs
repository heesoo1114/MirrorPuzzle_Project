using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilmPuzzle : InteractionObject
{
    [SerializeField]
    private Animator Shake_anim;

    [SerializeField]
    private Image film_Img;
    [SerializeField]
    private Image img;

    [SerializeField]
    private GameObject hint;

    [SerializeField]
    private Button btn;
    [SerializeField]
    private Image btn_img;
    private Color color;

    [SerializeField]
    private AudioClip clickSound;
    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        btn.onClick.AddListener(OnClick);
        color.a = 1f;
    }

    public void OnClick()
    {
        if (GameManager.Inst.WorldType == WorldType.MirrorWorld)
        {
            color.a -= 0.1f;
            btn_img.color = color;

            audioSource.PlayOneShot(clickSound);
        }
    }

    public override void InteractionEvent()
    {
        if (GameManager.Inst.WorldType == WorldType.RealWorld)
        {
            film_Img.gameObject.SetActive(true);
        }
        else
        {
            film_Img.gameObject.SetActive(false);
        }
        hint.SetActive(true);
    }

}
