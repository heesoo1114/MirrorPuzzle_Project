using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    SpriteRenderer flowerpot;
    public SpriteRenderer ChangeFlowerpot;

    void Start()
    {
        flowerpot = GetComponent<SpriteRenderer>();
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LightCollider")
        {
            flowerpot = ChangeFlowerpot;
            Debug.Log(".");
        }
    }
}
