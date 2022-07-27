using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BigBrotherPuzzle : MonoBehaviour
{
    private int equipPanelCnt;

    private int checkRedBear;
    private int checkBlueBear;

    [SerializeField]
    private Transform checkEquipPanel;
    [SerializeField]
    private Image puzzleImage;
    [SerializeField]
    private Image gunReloadImage;

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
            puzzleImage.gameObject.SetActive(true);
            gunReloadImage.gameObject.SetActive(false);
        }
    }

    public void BlueBearClick()
    {
        GameObject clickBear = EventSystem.current.currentSelectedGameObject;
        clickBear.SetActive(false);

        if (checkEquipPanel.GetChild(equipPanelCnt).GetChild(0).gameObject.CompareTag("RedBullet"))
        {
            Debug.Log("ÆÄ¶õ°õÀ» »¡°£ ÃÑ¾Ë·Î ½ú´Ù.");
        }

        checkBlueBear++;

        equipPanelCnt++;
        if (equipPanelCnt >= 9)
            equipPanelCnt = 0;

        if (checkRedBear + checkBlueBear >= 9)
            Debug.Log("ÆÛÁñ Å¬¸®¾î");
    }

    public void RedBearClick()
    {
        GameObject clickBear = EventSystem.current.currentSelectedGameObject;

        if (checkEquipPanel.GetChild(equipPanelCnt).GetChild(0).gameObject.CompareTag("BlueBullet"))
        {
            checkRedBear++;
            clickBear.SetActive(false);
        }
        else if (checkEquipPanel.GetChild(equipPanelCnt).GetChild(0).gameObject.CompareTag("RedBullet"))
        {
            Debug.Log("½ÇÆÐ");
            clickBear.SetActive(false);
        }

        equipPanelCnt++;
        if (equipPanelCnt >= 9)
            equipPanelCnt = 0;

        if (checkRedBear + checkBlueBear >= 9)
            Debug.Log("ÆÛÁñ Å¬¸®¾î");
    }
}
