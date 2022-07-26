using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigBrotherPuzzle : MonoBehaviour
{
    public int equipPanelCnt = 0;

    [SerializeField]
    private Transform checkEquipPanel;
    [SerializeField]
    private Image puzzleImage;
    [SerializeField]
    private Image gunReloadImage;

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
        Debug.Log(Check());
        if(Check())
        {
            puzzleImage.gameObject.SetActive(true);
            gunReloadImage.gameObject.SetActive(false);
        }
    }

    public void BlueBearClick()
    {
        if(checkEquipPanel.GetChild(equipPanelCnt).GetChild(0).gameObject.CompareTag(""))
        {

        }
    }

    public void RedBearClick()
    {

    }
}
