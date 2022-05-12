using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _maxSpeed = 5f;
    public float _acceleration = 50f;
    public float _deAcceleration = 50f;
    public TextDatas _textDatas;

    protected float _currentVelocity = 3f;
    protected Vector2 _movementDir;

    private Rigidbody2D _rigid;
    private bool _isWarping;
    private bool _findMirror;

    private UIManager _uiManager;
    private Animator _animator;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _uiManager = FindObjectOfType<UIManager>();
        _animator = GetComponent<Animator>();
    }

    // ����Ǵ� ���� �ݺ� => 1 ������ �ѹ��� ȣ��
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_uiManager.IsActiveTextPanal())
            {
                _uiManager.ActiveTextPanal();
            }

            else
            {
                FindMirror();
            }
        }
    }

    private void FindMirror()
    {
        if (!_findMirror) return;

        string str = _textDatas.FindTextData("FIND_MIRROR");
        _uiManager.ActiveTextPanal(str);
        _rigid.velocity = Vector2.zero;
        _uiManager.OnUI = true;
    }

    void FixedUpdate()
    {
        if (_uiManager.OnUI) return;

        InputDirection();

        _rigid.velocity = _movementDir * _currentVelocity;

        PlayerAnimation();
    }

    private void InputDirection()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        if (dir.sqrMagnitude > 0)
        {
            // ���� ������ �� ������ ���� ���ϰ� �ִ� ������ �ݴ�� 
            // �ӵ��� 0���� �ʱ�ȭ�� ��Ų��
            if (Vector2.Dot(dir, _movementDir) < 0)
            {
                _currentVelocity = 0f;
            }

            // ���� ���� ��Ŵ
            _movementDir = dir.normalized;
        }

        _currentVelocity = CalcSpeed(dir.normalized);
        // (0,0) == ������ ������ ���ٸ�
        // �� ��ȭ�� ����
    }

    private float CalcSpeed(Vector2 dir)
    {
        float velocity = _currentVelocity;

        if (dir.sqrMagnitude > 0)
        {
            velocity += _acceleration * Time.fixedDeltaTime;
        }

        else
        {
            velocity -= _deAcceleration * Time.fixedDeltaTime;
        }

        return Mathf.Clamp(velocity, 0f, _maxSpeed);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mirror"))
        {
            _uiManager.ShowInteractionUI(collision.transform.position);
            _findMirror = true;
            //_uiManager.ShowTextPanal("��? �ſ��̴�!");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            if (_isWarping) return;
            WarpZone warpZone = collision.gameObject.GetComponent<WarpZone>();
            Vector2 warpPoint = warpZone.WarpPoint;

            // �� �ٲ� �������� �ӽ÷� �ּ� �س����Կ�
            //if (_movementDir.x == warpZone._offset.x ||
            //    _movementDir.y == warpZone._offset.y)
            {
                _isWarping = true;
                StartCoroutine(WarpPlayer(warpPoint));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mirror"))
        {
            _uiManager.UnShowInteractionUI();
            _findMirror = false;
        }
    }

    private IEnumerator WarpPlayer(Vector2 warpPoint)
    {
        _uiManager.FadeScreen(true);
        yield return new WaitForSeconds(0.5f);
        transform.position = warpPoint;
        yield return new WaitForSeconds(0.1f);
        _uiManager.FadeScreen(false);
        yield return new WaitForSeconds(0.5f);
        _isWarping = false;
    }

    private void PlayerAnimation()
    {
        if (_rigid.velocity.x > 0.05f)
            _animator.Play("RightWalk");

        else if (_rigid.velocity.x < -0.05f)
            _animator.Play("LeftWalk");

        else if (_rigid.velocity.y > 0.05f)
            _animator.Play("UpWalk");

        else if (_rigid.velocity.y < -0.05f)
            _animator.Play("DownWalk");
    }
}