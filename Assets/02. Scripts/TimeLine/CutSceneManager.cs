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
    private int _currentLineIdx;

    private CutSceneLine CurrentLine => _currentCutScene[_currentLineIdx];

    private bool _isPlaying;
    private bool _isScriptStarted;

    private void Start()
    {
        StartCutScene("START");
    }

    public void Update()
    {
        if(_isPlaying && _isScriptStarted)
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
        if (_currentCutScene != null && _currentLineIdx < _currentCutScene.Count) return; 

        _isPlaying = true;
        _isScriptStarted = false;

        _currentCutScene = _cutSceneDataList.Find( x =>x.cutSceneID.Equals(cutSceneID));
        _currentLineIdx = 0;

        _currentDirector = _cutSceneDirectorList.Find(x => x.cutSceneID.Equals(_currentCutScene.cutSceneID));

        _currentDirector?.Play();
    }

    public void PlayCutSceneAct()
    {
        if (_isPlaying == false) return;
        if(_textPanel.IsOutput)
        {
            _textPanel.ImmediatelyEndOutput();
            return;
        }
        if (_currentLineIdx >= _currentCutScene.Count)
        {
            _isPlaying = false;
            Destroy(_currentDirector.gameObject);
            _currentDirector = null;
            return;
        }
        if (_isScriptStarted == false)
            _isScriptStarted = true;


        _textPanel.ShowTextPanal(CurrentLine.lineText, CurrentLine.name);
        _currentLineIdx++;
    }

}
