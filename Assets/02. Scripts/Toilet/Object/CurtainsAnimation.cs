using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainsAnimation : MonoBehaviour
{
    
     Animator anim;
     BoxCollider2D _boxCollider;

    bool isCurtain = true;

    public GameObject closeCurtatin;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        anim.SetBool("isOpen", false);
    }

    public void Curtains()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Close()
    {
        anim.SetBool("isOpen", false);
    }

    private void OnEnable()
    {
        anim.SetBool("isOpen", isCurtain);
    }


}
