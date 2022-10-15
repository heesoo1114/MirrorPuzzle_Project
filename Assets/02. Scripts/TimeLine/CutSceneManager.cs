using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutSceneManager : MonoSingleton<CutSceneManager>
{
    [SerializeField] private TextSystem _textPanel;
    [SerializeField] private List<CutSceneDirector> _cutSceneDirectorList;
    [SerializeField] private CinemachineVirtualCameraBase _timeLineCam;

    private CutSceneSO _currentCutScene;
    private CutSceneDirector _currentDirector;
    private int _scriptIdx;
    private int _lineIdx;

    private CutSceneScript _currentScript;
    private CutSceneLine _currentLine;

    private bool _isPlaying = false;
    private bool _isScriptStarted;

    private EGameState _beforeState;

    public void StartCutScene(string cutSceneID)
    {
        if (_isPlaying) return;
        if (_currentCutScene != null && _lineIdx < _currentCutScene.Count) return;

        _isPlaying = true;
        _isScriptStarted = false;


        _currentDirector = _cutSceneDirectorList.Find(x => x.cutSceneID.Equals(cutSceneID));

        if (_currentDirector == null) return;

        _currentCutScene = _currentDirector.CurrentCutScene;

        _beforeState = GameManager.Inst.GameState;
        GameManager.Inst.ChangeGameState(EGameState.Timeline);
        EventManager.TriggerEvent($"START_{_currentCutScene.cutSceneID}CUTSCENE");

        _textPanel.OnKeyDownSpace += PlayCutSceneAct;

        _scriptIdx = 0;

        _timeLineCam.m_Priority = 20;

        _currentDirector?.Play();
    }

    public void StartTextScene()
    {
        if (_isPlaying == false) return;
        if (_isScriptStarted) return;

        if (_isScriptStarted == false)
            _isScriptStarted = true;

        if (!_currentDirector.IsPuased)
        {
            _currentDirector.Pause();
        }

        _lineIdx = 0;
        _currentScript = _currentCutScene[_scriptIdx++];
        PlayCutSceneAct();
    }

    public void EndTextScene()
    {
        if (_isPlaying == false) return;

        if (_isScriptStarted)
        {
            _isScriptStarted = false;
        }

        _textPanel.UnShowTextPanal();

        if (_currentDirector.IsPuased)
        {
            _currentDirector.Play();
        }
    }

    public void PlayCutSceneAct()
    {
        if (_isPlaying == false) return;
        if (_textPanel.IsOutput)
        {
            _textPanel.ImmediatelyEndOutput();
            return;
        }
        if (_lineIdx >= _currentScript.Count)
        {
            _isScriptStarted = false;
            _currentDirector.Play();
            return;
        }

        _currentLine = _currentScript[_lineIdx];

        if (_textPanel.ShowTextPanal(_currentLine.lineText, _currentLine.name))
        {
            _lineIdx++;
        }
    }

    public void EndCutScene()
    {
        if (_isPlaying == false) return;

        FadeScreen.FadeOut(0f);
        if (_beforeState != EGameState.Timeline)
        {
            GameManager.Inst.ChangeGameState(_beforeState);
        }

        else
        {
            GameManager.Inst.ChangeGameState(EGameState.Game);
        }
        EventManager.TriggerEvent($"END_{_currentCutScene.cutSceneID}CUTSCENE");

        _isScriptStarted = false;
        _currentDirector.Pause();
        _currentDirector = null;
        _lineIdx = 0;
        _currentCutScene = null;
        _textPanel.OnKeyDownSpace -= PlayCutSceneAct;
        _timeLineCam.m_Priority = 0;

        _isPlaying = false;

    }
}

