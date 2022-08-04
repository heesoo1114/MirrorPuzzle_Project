using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BigBrotherPuzzle : MonoBehaviour
{
    public UnityEvent bb_startEvent;
    public UnityEvent bb_shootEvent;

    private int equipPanelCnt;

    private int checkRedBear;
    private int checkBlueBear;

    [SerializeField]
    private Transform checkEquipPanel;
    [SerializeField]
    private Image puzzleImage;
    [SerializeField]
    private Image gunReloadImage;

    [SerializeField]
    private Image clearImage;
    [SerializeField]
    private Image faliedImage;


    private void OnEnable()
    {
        equipPanelCnt = Random.Range(0, 9);
        Debug.Log(equipPanelCnt);
    }

    bool Check()
    {
        for (int i = 0; i < checkEquipPanel.childCount; ++i)
        {
            if (checkEquipPanel.GetChild(i).childCount != 1)
                return false;
        }

        return true;
    }

    public void StartRulletGame()
    {
        if(Check())
        {
            bb_startEvent?.Invoke();
            puzzleImage.gameObject.SetActive(true);
            gunReloadImage.gameObject.SetActive(false);
        }
    }

    public void BlueBearClick()
    {
        GameObject clickBear = EventSystem.current.currentSelectedGameObject;

        if (checkEquipPanel.GetChild(equipPanelCnt).GetChild(0).gameObject.CompareTag("BlueBullet"))
        {
            clickBear.SetActive(false);
            checkBlueBear++;
        }
        else if (checkEquipPanel.GetChild(equipPanelCnt).GetChild(0).gameObject.CompareTag("RedBullet"))
        {
            checkBlueBear++;
            Image clickBearImage = clickBear.GetComponent<Image>();

            Color color = clickBearImage.color;
            color = Color.red;
            clickBearImage.color = color;
            // clickBear의 색깔의 R값을 255로
        }

        bb_shootEvent?.Invoke();
        equipPanelCnt++;

        if (equipPanelCnt >= 9)
            equipPanelCnt = 0;

        if (checkRedBear + checkBlueBear >= 9)
        {
            PuzzleClear();
        }
    }

    public void RedBearClick()
    {
        GameObject clickBear = EventSystem.current.currentSelectedGameObject;

        if (checkEquipPanel.GetChild(equipPanelCnt).GetChild(0).gameObject.CompareTag("BlueBullet"))
        {
            checkRedBear++;

            Image clickBearImage = clickBear.GetComponent<Image>();

            Color color = clickBearImage.color;
            color.r = 0;
            clickBearImage.color = color;
            // clickBear의 색깔의 R값을 0으로
        }
        else if (checkEquipPanel.GetChild(equipPanelCnt).GetChild(0).gameObject.CompareTag("RedBullet"))
        {
            puzzleImage.gameObject.SetActive(false);
            faliedImage.gameObject.SetActive(true);
        }

        bb_shootEvent?.Invoke();

        equipPanelCnt++;
        if (equipPanelCnt >= 9)
            equipPanelCnt = 0;

        if (checkRedBear + checkBlueBear >= 9)
        {
            PuzzleClear();
        }
    }

    public void PuzzleClear()
    {
        CutSceneManager.Inst.StartCutScene("ENDGAME");

        puzzleImage.gameObject.SetActive(false); 
        clearImage.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        
    }
}
