using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D _rigid;
    private bool _isWarping;

    private UIManager _uiManager;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        _rigid.velocity = dir.normalized * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Trigger"))
        {
            if (_isWarping) return;
            _isWarping = true;
            Vector2 warpPoint = collision.GetComponent<WarpZone>().WarpPoint;
            StartCoroutine(WarpPlayer(warpPoint));
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

