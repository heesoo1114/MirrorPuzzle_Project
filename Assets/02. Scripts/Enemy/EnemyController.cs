using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _followTime;
    private Vector2 _currentDir;
    private Transform _tagetTrs;
    private Rigidbody2D _rigid;


    void Start()
    {
        _tagetTrs = Define.PlayerRef.transform;
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameObject.activeSelf == false) return;

        _currentDir = _tagetTrs.position - transform.position;
        _currentDir.Normalize();

        _rigid.velocity = _currentDir * _moveSpeed ;

        if(_currentDir.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void InitEnemy(float followTime)
    {
        _followTime = followTime;
        StartCoroutine(DestroyDelay());
        gameObject.SetActive(true);
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(_followTime);

        gameObject.SetActive(false);
    }
}
