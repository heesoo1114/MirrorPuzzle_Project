using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateMirror : MonoBehaviour
{
    [SerializeField] private Sprite _leftSprite = null;
    [SerializeField] private Sprite _rightSprite = null;

    private Image _image = null;
    [SerializeField]
    private RectTransform _recTrm = null;

    private LightMove lightMove;

    private void Awake()
    {
        _recTrm = GetComponent<RectTransform>();
        _image = GetComponent<Image>();

        lightMove = gameObject.transform.parent.GetChild(0).GetComponent<LightMove>();

        _state = State.Left;
    }

    public enum State
    {
        Left,
        Right
    }

    public State _state;

    public void ClickMirror()
    {
        if (lightMove.isMove)
            return;

        if (_state == State.Left)
        {
            _state = State.Right;
            transform.DORotate(new Vector3(0, 0, 90), 1f);
        }
        else if (_state == State.Right)
        {
            _state = State.Left;
            transform.DORotate(new Vector3(0, 0, 0), 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float rotation = 45f;
        switch (_state)
        {
            case State.Left:
                rotation = 45f;
                break;
            case State.Right:
                rotation = -45f;
                break;
        }

        collision.transform.position = transform.position;
        collision.transform.Rotate(0, 0, rotation);

        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    float rotation = 45f;
        //    switch (_state)
        //    {
        //        case State.Left:
        //            rotation = 45f;
        //            break;
        //        case State.Right:
        //            rotation = -45f;
        //            break;
        //    }

        //    collision.transform.Rotate(0,0,rotation);
        //}
    }
}
