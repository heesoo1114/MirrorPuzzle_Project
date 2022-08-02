using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrowFingding : InteractionObject
{
<<<<<<< HEAD
    public override void InteractionEvent()
=======
    public int count = 0;

    [SerializeField]
    private Image chips_Image;
    //[SerializeField]
    //private SpriteRenderer[] draws;
    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clickmerrer()
    {
    }

    public void ObjectFind()
    {
        count++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
>>>>>>> OIF
    {
        Debug.Log(".");
    }
    
}
