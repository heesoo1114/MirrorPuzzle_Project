using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private List<CutSceneSO> _cutSceneDataList;

    [SerializeField] private Character _characterFormPref;
    private Queue<CutSceneAction> _currentActionQueue;
    private Dictionary<string, Character> _characterDict;

    public void PlayCutScene(string cutSecneID)
    {
        CutSceneSO cutSceneData = _cutSceneDataList.Find(x => x.cutSceneID == cutSecneID);

        _currentActionQueue = new Queue<CutSceneAction>(cutSceneData.cutSceneActionList);
        _characterDict = new Dictionary<string, Character>();

        StartCoroutine(PlayCutSceneCoroutine());
    }

    private IEnumerator PlayCutSceneCoroutine()
    {
        while(_currentActionQueue.Count != 0)
        {
            CutSceneAction action = _currentActionQueue.Dequeue();
            Character character = GetCharacter(action.targetCharacter);

            action.TakeAction(character);

            if (action.actionPlayType == ECutScenePlayType.Append)
            {
                yield return new WaitForSeconds(action.nextActionDelay);
            }
        }
    }

    private Character GetCharacter(CharacterData data)
    {
        Character character = null;
        if(_characterDict.TryGetValue(data.name, out character))
        {
            return character;
        }

        else
        {
            character = Instantiate(_characterFormPref);
            character.Init(data);
            _characterDict.Add(data.name, character);

            return character;
        }
    }
}
