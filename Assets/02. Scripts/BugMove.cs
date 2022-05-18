using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BugMove : MonoBehaviour
{
    private BugManager bugManager;
    public Vector2 currentDir = Vector2.zero;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float offset = 3f;

    private float targetAngle;

    void Start()
    {

        RandomDir();
    }

    void Update()
    {
        if (Limit())
        {
            RandomDir();
            return;
        }

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    public void Init(BugManager manager)
    {
        bugManager = manager;
        this.enabled = true;
        gameObject.SetActive(true);
    }

    private void DoRotate()
    {
        transform.DORotate(new Vector3(0f, 0f, targetAngle), 0.3f);
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, targetAngle), Time.deltaTime * rotateSpeed);
    }

    private void RandomDir()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        currentDir = new Vector2(x, y).normalized;

        targetAngle = Mathf.Atan2(currentDir.y, currentDir.x) * Mathf.Rad2Deg;
        DoRotate();
    }

    private bool Limit()
    {
        if ((currentDir.x > 0.1f && transform.position.x >= bugManager.maxPos.x - offset) ||
            (currentDir.x < 0.1f && transform.position.x <= bugManager.minPos.x + offset) ||
            (currentDir.y > 0.1f && transform.position.y >= bugManager.maxPos.y - offset) ||
            (currentDir.y < 0.1f && transform.position.y <= bugManager.minPos.y + offset))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void Click()
    {
        bugManager.DeadBug(this);
        Destroy(gameObject);
    }

}
// 움직임, 클릭시 사라짐