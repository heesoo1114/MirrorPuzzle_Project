using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightLineGameManager : SingleUI<LightLineGameManager>
{
    public UnityEvent gameEndEvent;
    public UnityEvent gameResetEvent;

    private bool _isStart = false;

    private bool _isClear = false;

    public bool IsClear => _isClear;
    bool isPlaying;

    [SerializeField] private WarpZone _hallWayWarpZone;

    [SerializeField] private GameObject _collider;

    private void Start() 
    {
        isPlaying = (PlayerPrefs.GetInt("LightLineGameIsPlaying") == 1);
        _isClear = (PlayerPrefs.GetInt("LightLineGameIsClear") == 1);

    }

    public static void StartGame()
    {
        if (CheckInstance()) return;

        inst.StartLightGame();
    }

    public override bool Init()
    {
        if (base.Init())
        {
            return false;
        }

        _isStart = false;
        _isClear = false;
        PlayerPrefs.SetInt("LightLineGameIsClear", 0);
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);

        return true;
    }

    public void StartLightGame()
    {
        if (_isStart == true) return;
        if (_isClear) return;
        _isStart = true;
        gameObject.SetActive(true);
        transform.localScale = Vector3.one;
        GameManager.Inst.ChangeGameState(EGameState.UI);
    }

    public void ResetGame()
    {
        gameResetEvent?.Invoke();
    }

    public void GameEnd()
    {
        GameManager.Inst.ChangeGameState(EGameState.Game);

        _isStart = false;
        _isClear = true;
        PlayerPrefs.SetInt("LightLineGameIsClear", 1);

        transform.localScale = Vector3.zero;
        gameEndEvent?.Invoke();
        //InventorySystem.Inst.AddItem("LIBRARYKEY");
        gameObject.SetActive(false);
        if (_hallWayWarpZone.isLock)
        {
            _hallWayWarpZone.isLock = false;
            _hallWayWarpZone.lockMessage = "";
        }


            gameEndEvent.AddListener(() => { isPlaying = true; });

        if (isPlaying)
            PlayerPrefs.SetInt("LightLineGameIsPlaying", 1);
    }
}
