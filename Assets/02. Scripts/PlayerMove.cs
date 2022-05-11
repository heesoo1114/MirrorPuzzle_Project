using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rigid;
    private Animator animator;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;

        rigid.velocity = new Vector2(x, y);

        if (x > 0.01f)
        {
            animator.Play("RightWalk");
        }
        else if(x < -0.01f)
        {
            animator.Play("LeftWalk");
        }
        else if(y > 0.01f)
        {
            animator.Play("UpWalk");
        }
        else if (y < -0.01f)
        {
            animator.Play("DownWalk");
        }
    }
}
