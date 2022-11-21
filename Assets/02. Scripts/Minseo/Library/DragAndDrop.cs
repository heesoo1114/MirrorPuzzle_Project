using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _curveMovement;
    [SerializeField]
    private AnimationCurve _curveSacle;

    private float appearTime = 0.5f;
    private float returnTime = 0.1f;

    [field: SerializeField]
    public Vector2Int blockCount { private set; get; }

    public void SetUp(Vector3 parentPosition)
    {
        StartCoroutine(OnMoveTo(parentPosition, appearTime));
    }

    private void OnMouseDown()
    {
        StopCoroutine("OnSacle");
        StartCoroutine("OnSacle", Vector3.one);
    }

    private void OnMouseDrag()
    {
        Vector3 gap = new Vector3(0, blockCount.y * 0.5f + 1, 10);
        transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition) + gap;
    }

    private void OnMouseUp()
    {
        StopCoroutine("OnSacle");
        StartCoroutine("OnSacle", Vector3.one * 0.5f);
        StartCoroutine(OnMoveTo(transform.parent.position, returnTime));
    }

    private IEnumerator OnMoveTo(Vector3 end, float time)
    {
        Vector3 start = transform.position;
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            transform.position = Vector3.Lerp(start, end, _curveMovement.Evaluate(percent));

            yield return null;
        }
    }

    private IEnumerator OnSacle(Vector3 end)
    {
        Vector3 start = transform.localPosition;
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / returnTime;

            transform.localPosition = Vector3.Lerp(start, end, _curveSacle.Evaluate(percent));

            yield return null;
        }
    }
}
