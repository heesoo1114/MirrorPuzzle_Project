using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

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

    private Animator _timeLineAnimator;
    private Animator _visualAnimator;

    private ParticleSystem _walkParticle;
    public UnityEvent OnTriggerInteraction;

    private RoomType _currentRoomType;

    public RoomType CurrentRoom => _currentRoomType;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        _timeLineAnimator = GetComponent<Animator>();
        _visualAnimator = transform.Find("VisualSprite").GetComponent<Animator>();
        _walkParticle = GetComponentInChildren<ParticleSystem>();

        _currentRoomType = RoomType.Kitchen;
    }

    private void Update()
    {
        if (GameManager.Inst.GameState != EGameState.Game) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnTriggerInteraction?.Invoke();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.Inst.GameState != EGameState.Game)
        {
            _rigid.velocity = Vector2.zero;
            return;
        }

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
            if (Vector2.Dot(dir, _movementDir) < 0)
            {
                _currentVelocity = 0f;
            }

            _movementDir = dir.normalized;
            _walkParticle.gameObject.SetActive(true);
        }
        else
        {
            _walkParticle.gameObject.SetActive(false);
        }

        _movementDir = dir.normalized;

        _currentVelocity = CalcSpeed(dir.normalized);
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.Inst.GameState != EGameState.Game) return;

        if (collision.gameObject.CompareTag("Trigger"))
        {
            if (_isWarping) return;
            WarpZone warpZone = collision.gameObject.GetComponent<WarpZone>();

            if (warpZone.isLock)
            {
                TextSystem.Inst.ActiveTextPanal(warpZone.lockMessage);
                return;
            }
            _isWarping = true;

            _currentRoomType = warpZone.targetRoom;

            StartCoroutine(WarpPlayer(warpZone));
        }
    }

    private IEnumerator WarpPlayer(WarpZone warpZone)
    {
        FadeScreen.FadeIn(0.5f);
        yield return new WaitForSeconds(0.5f);
        transform.position = warpZone.WarpPoint;
        yield return new WaitForSeconds(0.1f);
        FadeScreen.FadeOut(0.5f);
        yield return new WaitForSeconds(0.5f);
        LocationTextBar.ActiveRoomText(warpZone.RoomName);
        _isWarping = false;

        EventManager.TriggerEvent($"ENTER_{warpZone.targetRoom.ToString()}");
    }

    private void PlayerAnimation()
    {
        if (_rigid.velocity.x > 0.05f)
        {
            _visualAnimator.Play("RightWalk");
        }

        else if (_rigid.velocity.x < -0.05f)
        {
            _visualAnimator.Play("LeftWalk");
        }

        else if (_rigid.velocity.y > 0.05f)
        {
            _visualAnimator.Play("UpWalk");
        }

        else if (_rigid.velocity.y < -0.05f)
        {
            _visualAnimator.Play("DownWalk");
        }
    }

    public void ShakeObject()
    {
        _timeLineAnimator.enabled = false;
        transform.DOShakePosition(0.5f, 0.5f).OnComplete(() => _timeLineAnimator.enabled = true);
    }

    public enum WalkType { RightWalk, LeftWalk, UpWalk, DownWalk }
    public void PlayAnimation(string walkType)
    {
        if (_visualAnimator == null) return;
        if (walkType == null || walkType == "") return;
        StopAllCoroutines();

        if (walkType.Contains("Walk"))
        {
            StartCoroutine(PlayAnimationCoroutine(walkType));
        }

        else
        {
            _visualAnimator.Play(walkType);
        }
    }

    private IEnumerator PlayAnimationCoroutine(string walkType)
    {
        while (true)
        {
            _visualAnimator.Play(walkType);

            yield return new WaitForFixedUpdate();
        }
    }
}

        