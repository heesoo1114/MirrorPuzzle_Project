using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    public float speed = 7f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, Time.deltaTime * speed);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rigidbody.velocity = Vector3.zero;
    }
}
