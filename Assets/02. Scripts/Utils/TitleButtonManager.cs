using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingPanel = null;
    [SerializeField] private CanvasGroup canvasGroup = null;
    [SerializeField] private GameObject mirror_img;

    private bool isSettingPanelOn = false;

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadGame()
    {

    }

    public void SettingPanelOnOff()
    {
        if (isSettingPanelOn == false) SettingPanel.SetActive(true);
        mirror_img.gameObject.SetActive(false);
        canvasGroup.DOFade(isSettingPanelOn ? 0f : 1f, 0.5f);
        isSettingPanelOn = !isSettingPanelOn;
        if (isSettingPanelOn == false) SettingPanel.SetActive(false);
        mirror_img.gameObject.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
