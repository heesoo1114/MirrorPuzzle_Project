using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorPuzzle : InteractionObject
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

    void Update()
    {
        if(!(gameObjects[0].activeSelf)) // ����
            isStampOff = true;
        if (!(gameObjects[1].activeSelf)) // Ȳ��
            isGoldOff = true;
        if (!(gameObjects[2].activeSelf)) // å
            isBookOff = true;

        if (isStampOff)
            stampButton.gameObject.SetActive(isStampOff);
        if (isGoldOff)
            goldButton.gameObject.SetActive(isGoldOff);
        if (isBookOff)
            bookButton.gameObject.SetActive(isBookOff);
    }

    public override void InteractionEvent()
    {
        Debug.Log("����");
        mirrorUI.gameObject.SetActive(true);
    }

    public override void ExitInteraction() 
    {
        mirrorUI.gameObject.SetActive(false);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        mirrorUI.gameObject.SetActive(false);
    }
}
