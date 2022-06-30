using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorPuzzle : MonoBehaviour
{
    private bool isStampOff;
    private bool isGoldOff;
    private bool isBookOff;

    [SerializeField]
    private GameObject[] gameObjects;

    [SerializeField]
    private Image mirrorUI;

    [SerializeField]
    private Button stampButton;
    [SerializeField]
    private Button goldButton;
    [SerializeField]
    private Button bookButton;


    void Start()
    {
        
    }

    void Update()
    {
        if(!(gameObjects[0].activeSelf)) // 도장
            isStampOff = true;
        if (!(gameObjects[1].activeSelf)) // 황금
            isGoldOff = true;
        if (!(gameObjects[2].activeSelf)) // 책
            isBookOff = true;

        if (isStampOff)
            stampButton.gameObject.SetActive(isStampOff);
        if (isGoldOff)
            goldButton.gameObject.SetActive(isGoldOff);
        if (isBookOff)
            bookButton.gameObject.SetActive(isBookOff);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            mirrorUI.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        mirrorUI.gameObject.SetActive(false);
    }

    public void StampButtonClick()
    {

    }

    public void GoldButtonClick()
    {

    }

    public void BookButtonClick()
    {

    }
}
