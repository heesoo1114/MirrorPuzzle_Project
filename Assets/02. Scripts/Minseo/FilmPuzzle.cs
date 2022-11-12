using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

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

    public UnityEvent OnFilmClear;
    bool isPlaying;


    private void Start()
    {
        btn.onClick.AddListener(OnClick);
        color.a = 1f;
        isPlaying = (PlayerPrefs.GetInt("FilmPuzzle") == 1);
    }

    public void OnClick()
    {
        if (btn_img.color.a <= 0f) return;

        if (GameManager.Inst.WorldType == WorldType.MirrorWorld)
        {
            color.a -= 0.1f;
            btn_img.color = color;

            if(btn_img.color.a <= 0f)
            {
                Sequence seq = DOTween.Sequence();
                seq.Append(film_Img.transform.DOShakePosition(1f, 1, 3));
                seq.AppendCallback(()=> film_Img.gameObject.SetActive(false));
                seq.AppendCallback(()=> GameManager.Inst.ChangeGameState(EGameState.Game));
                seq.AppendCallback(() => OnFilmClear?.Invoke());

                return;
            }

            //오류 있어서 일단 꺼놨어요
            //audioSource.PlayOneShot(clickSound);
        }
    }

    public override void InteractionEvent()
    {
        if (GameManager.Inst.WorldType == WorldType.RealWorld)
        {
            TextSystem.Inst.ActiveTextPanal("밝아서 잘 보이지 않는다.");
            return;
        }

        GameManager.Inst.ChangeGameState(EGameState.UI);
        film_Img.gameObject.SetActive(true);

        hint.SetActive(true);

        OnFilmClear.AddListener(() => { isPlaying = true; });

        if (isPlaying)
            PlayerPrefs.SetInt("FilmPuzzle", 1);
    }

}
