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

        isCurtain = false;
        anim.SetBool("isOpen", isCurtain);
        
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        closeCurtatin.GetComponent<PolygonCollider2D>().enabled = true;
        
    }

    public void Curtains()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Close()
    {

        isCurtain = false;
        anim.SetBool("isOpen", isCurtain);

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        closeCurtatin.GetComponent<PolygonCollider2D>().enabled = true;

    }

    private void OnEnable()
    {
        anim.SetBool("isOpen", isCurtain);
    }


}
