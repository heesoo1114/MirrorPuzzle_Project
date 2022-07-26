using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BugManager : MonoBehaviour
{
    public BugMove bugPref;
    public Vector2 minPos;
    public Vector2 maxPos;

    [SerializeField] private int generateCnt;
    private List<BugMove> bugs;

    private bool _isStart;

    public void Init()
    {
        if (_isStart) return;
        _isStart = true;
        Camera mainCam = Camera.main;
        minPos = mainCam.ViewportToWorldPoint(Vector2.zero);
        maxPos = mainCam.ViewportToWorldPoint(Vector2.one);

        bugs = new List<BugMove>();
        gameObject.SetActive(true);
        transform.DOScale(Vector3.one, 0.8f).SetEase(Ease.InOutBounce).OnComplete(GenerateBug);
    }

    void Start()
    {

    }

    public void GenerateBug()
    {
        for (int i = 0; i < generateCnt; i++)
        {
            float xPos = Random.Range(minPos.x, maxPos.x);
            float yPos = Random.Range(minPos.y, maxPos.y);

            BugMove bug = Instantiate(bugPref, bugPref.transform.parent);
            bug.transform.position = new Vector3(xPos, yPos);
            bug.Init(this);
            bugs.Add(bug);
        }
    }

    public void DeadBug(BugMove bug)
    {
        bugs.Remove(bug);

        if(bugs.Count <= 0)
        {
<<<<<<< HEAD
            GameManager.Inst.SetGameState(false);
=======
            GameManager.Inst.gameState = EGameState.Game;
>>>>>>> OIF
            _isStart = false;
            transform.DOScale(Vector3.zero, 0.8f).SetEase(Ease.InOutBounce).OnComplete(() => gameObject.SetActive(false));
        }
    }

}
// 积己 - 罚待 积己