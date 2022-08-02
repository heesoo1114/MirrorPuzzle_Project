using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private List<CutSceneSO> _cutSceneDataList;
    [SerializeField] private TextPanel _textPanel;
    [SerializeField] private List<CutSceneDirector> _cutSceneDirectorList;

    private CutSceneSO _currentCutScene;
    private CutSceneDirector _currentDirector;
    private int _scriptIdx;
    private int _lineIdx;

    private CutSceneScript _currentScript;
    private CutSceneLine _currentLine;

    private bool _isPlaying;
    private bool _isScriptStarted;

    private void Start()
    {
        StartCutScene("START");
    }

    public void Update()
    {
        if (_isPlaying && _isScriptStarted)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                PlayCutSceneAct();
            }
        }
    }

    public void StartCutScene(string cutSceneID)
    {
        if (_isPlaying) return;
        if (_currentCutScene != null && _lineIdx < _currentCutScene.Count) return; 

        _isPlaying = true;
        _isScriptStarted = false;

        _currentCutScene = _cutSceneDataList.Find( x =>x.cutSceneID.Equals(cutSceneID));
        
        _scriptIdx = 0;

        _currentDirector = _cutSceneDirectorList.Find(x => x.cutSceneID.Equals(_currentCutScene.cutSceneID));

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

    public void PlayCutSceneAct()
    {
        if (_isPlaying == false) return;
        if(_textPanel.IsOutput)
        {
            _textPanel.ImmediatelyEndOutput();
            return;
        }
        if (_lineIdx >= _currentScript.Count)
        {
            _isScriptStarted = false;
            _textPanel.UnShowTextPanal();
            _currentDirector.Play();
            return;
        }

        _currentLine = _currentScript[_lineIdx++];
        _textPanel.ShowTextPanal(_currentLine.lineText, _currentLine.name);
    }

    public void EndCutScene()
    {
        _isPlaying = false;
        _isScriptStarted = false;
        _currentDirector.Pause();
        _currentDirector = null;
        _lineIdx = 0;
        _currentCutScene = null;

        GameManager.Inst.UI.StartFadeOut(0f);
        GameManager.Inst.gameState = EGameState.Game;
    }
}
