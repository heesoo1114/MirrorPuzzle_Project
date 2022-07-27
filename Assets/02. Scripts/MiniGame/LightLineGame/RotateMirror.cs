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

    private void Awake()
    {
        _recTrm = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    public enum State
    {
        Left,
        Right
    }

    public State _state;

    private void Update()
    {
        if (_state == State.Left)
            _image.sprite = _leftSprite;
        else if (_state == State.Right)
            _image.sprite = _rightSprite;
    }

    public void ClickMirror()
    {
        if (_state == State.Left)
            _state = State.Right;
        else if (_state == State.Right)
            _state = State.Left;
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
