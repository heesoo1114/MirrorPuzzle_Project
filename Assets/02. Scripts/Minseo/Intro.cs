using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private GameObject _mirror;
    [SerializeField]
    private GameObject _titleUI;
    [SerializeField]
    private GameObject _image;

    private void Start()
    {
        Invoke("FadeIn", 2.5f);
    }

    void FadeIn()
    {
        _mirror.transform.DOMove(new Vector3(-1, -18, 1), 2f);
        _mirror.transform.DOScale(new Vector3(180, 180, 180), 2f);
        Invoke("TitleScene", 2f);
    }

    void TitleScene()
    {
        _mirror.SetActive(false);
        _titleUI.SetActive(true);
        _image.transform.DOScale(new Vector3(1, 1, 1), 2f);
    }
}
