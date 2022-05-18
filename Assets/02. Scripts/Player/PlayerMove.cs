using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    public float _maxSpeed = 5f;
    public float _acceleration = 50f;
    public float _deAcceleration = 50f;

    protected float _currentVelocity = 3f;
    protected Vector2 _movementDir;

    private Rigidbody2D _rigid;
    private bool _isWarping;
    private bool _findMirror;

    private Animator _animator;

    public UnityEvent OnTriggerInteraction;


    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // ����Ǵ� ���� �ݺ� => 1 ������ �ѹ��� ȣ��
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnTriggerInteraction?.Invoke();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.Inst.OnUI) return;

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
        }
        // ���� ���� ��Ŵ

        _movementDir = dir.normalized;

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

    private IEnumerator WarpPlayer(Vector2 warpPoint)
    {
        GameManager.Inst.UI.FadeScreen(true);
        yield return new WaitForSeconds(0.5f);
        transform.position = warpPoint;
        yield return new WaitForSeconds(0.1f);
        GameManager.Inst.UI.FadeScreen(false);
        yield return new WaitForSeconds(0.5f);
        _isWarping = false;
    }

    private void PlayerAnimation()
    {
        if (_rigid.velocity.x > 0.05f)
        {
            _animator.Play("RightWalk");
        }

        else if (_rigid.velocity.x < -0.05f)
        {
            _animator.Play("LeftWalk");
        }

        else if (_rigid.velocity.y > 0.05f)
        {
            _animator.Play("UpWalk");
        }

        else if (_rigid.velocity.y < -0.05f)
        {
            _animator.Play("DownWalk");
        }
    }
}