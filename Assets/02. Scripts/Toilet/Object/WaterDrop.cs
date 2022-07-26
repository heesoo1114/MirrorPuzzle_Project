using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{

    public float dropSpeed = 5f;
    Vector2 dir = Vector2.down;

    void Update()
    {
        transform.Translate(dir * dropSpeed * Time.deltaTime);



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
