using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _maxSpeed = 5f;
    public float _acceleration = 50f;
    public float _deAcceleration = 50f;

    protected float _currentVelocity = 3f;
    protected Vector2 _movementDir;

    private Rigidbody2D _rigid;
    private bool _isWarping;

    private UIManager _uiManager;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    void FixedUpdate()
    {
        InputDirection();

        _rigid.velocity = _movementDir * _currentVelocity;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            if (_isWarping) return;
            _isWarping = true;
            Vector2 warpPoint = collision.GetComponent<WarpZone>().WarpPoint;
            StartCoroutine(WarpPlayer(warpPoint));
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mirror"))
        {
            _uiManager.ShowInteractionUI(collision.transform.position);
            //_uiManager.ShowTextPanal("��? �ſ��̴�!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mirror"))
        {
            _uiManager.UnShowInteractionUI();
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
}
