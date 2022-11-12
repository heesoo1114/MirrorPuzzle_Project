using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingPanel = null;
    [SerializeField] private CanvasGroup canvasGroup = null;
    private bool isSettingPanelOn = false;

    public void NewGame()
    {
        PlayerPrefs.SetInt("LibraryBoxPuzzle", 0);
        PlayerPrefs.SetInt("Chest", 0);
        PlayerPrefs.SetInt("ToiletLetterInteraction", 0);
        PlayerPrefs.SetInt("InteractionKeyCheck", 0);
        PlayerPrefs.SetInt("InteractionKeyFilmClear", 0);
        PlayerPrefs.SetInt("FilmPuzzle", 0);
        PlayerPrefs.SetInt("InteractionBrotherNote", 0);
        PlayerPrefs.SetInt("LightLineGameIsPlaying", 0);
        PlayerPrefs.SetInt("LightLineGameIsClear", 0);
        PlayerPrefs.SetInt("InteractionKey", 0);

        SceneManager.LoadScene("Main");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void SettingPanelOnOff()
    {
        if (isSettingPanelOn == false) SettingPanel.SetActive(true);
        canvasGroup.DOFade(isSettingPanelOn ? 0f : 1f, 0.5f);
        isSettingPanelOn = !isSettingPanelOn;
        if (isSettingPanelOn == false) SettingPanel.SetActive(false);
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
