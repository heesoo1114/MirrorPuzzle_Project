using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public BugMove bugPref;
    public Vector2 minPos;
    public Vector2 maxPos;

    [SerializeField] private int generateCnt;
    private List<BugMove> bugs;

    private void Awake()
    {
        Camera mainCam = Camera.main;
        minPos = mainCam.ViewportToWorldPoint(Vector2.zero);
        maxPos = mainCam.ViewportToWorldPoint(Vector2.one);
    }

    void Start()
    {
        bugs = new List<BugMove>();
        GenerateBug();
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
            Debug.Log("场");
        }
    }

}
// 积己 - 罚待 积己