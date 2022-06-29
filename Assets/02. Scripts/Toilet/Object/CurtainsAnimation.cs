using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainsAnimation : MonoBehaviour
{
    
     Animator anim;
     BoxCollider2D _boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void open()
    {


        
        anim.SetBool("isOpen", false);
        
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
    }
}
