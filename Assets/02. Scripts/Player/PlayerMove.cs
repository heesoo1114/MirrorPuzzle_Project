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

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        _timeLineAnimator = GetComponent<Animator>();
        _visualAnimator = transform.Find("VisualSprite").GetComponent<Animator>();
        _walkParticle = GetComponentInChildren<ParticleSystem>();

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
                GameManager.Inst.UI.ActiveTextPanal(warpZone.lockMessage);
                return;
            }


            Vector2 warpPoint = warpZone.WarpPoint;
            _isWarping = true;
           

            StartCoroutine(WarpPlayer(warpPoint, warpZone.RoomName));
        }
    }

    private IEnumerator WarpPlayer(Vector2 warpPoint, string roomName)
    {
        GameManager.Inst.UI.StartFadeIn(0.5f);
        yield return new WaitForSeconds(0.5f);
        transform.position = warpPoint;
        yield return new WaitForSeconds(0.1f);
        GameManager.Inst.UI.StartFadeOut(0.5f);
        yield return new WaitForSeconds(0.5f);
        GameManager.Inst.UI.ActiveRoomText(roomName);
        _isWarping = false;
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
        transform.DOShakePosition(0.5f,0.5f).OnComplete(()=> _timeLineAnimator.enabled = true);
    }

    public enum WalkType { RightWalk, LeftWalk, UpWalk, DownWalk }
    public void PlayAnimation(string walkType)

    {
        if (_visualAnimator == null) return;
        if (walkType == null || walkType == "") return;
        StopAllCoroutines();

        StartCoroutine(PlayAnimationCoroutine(Animator.StringToHash(walkType)));
    }

    private IEnumerator PlayAnimationCoroutine(int hash)
    {
        while (GameManager.Inst.GameState == EGameState.Timeline)
        {
            _visualAnimator.Play(hash);

            yield return new WaitForFixedUpdate();
        }
    }
}
