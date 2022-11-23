using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    // 여러개를 배치하고 돌리기만 가능하게?

    public bool isMove = false;
    public bool isEnd = false;
    private TrailRenderer trail = null;

    [SerializeField]
    private Vector3 originPos = Vector3.zero;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        originPos = transform.localPosition;
    }

    private void Update()
    {
        if (isEnd == true) return;
        if (isMove == false) return;
        transform.Translate(transform.right * 10f * Time.deltaTime);
    }

    public void ResetLightMove()
    {
        isMove = false;
        isEnd = false;
        transform.localPosition = originPos;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        StartCoroutine(TrailReset());
    }

    IEnumerator TrailReset()
    {
        trail.time = 0;
        yield return new WaitForSeconds(0.1f);
        trail.time = 5;
    }

    public void StartGame()
    {
        isMove = true;
    }

    public void MoveStop()
    {
        isEnd = true;
    }

    public void TrailRemove()
    {
        trail.time = 0;
    }
}
