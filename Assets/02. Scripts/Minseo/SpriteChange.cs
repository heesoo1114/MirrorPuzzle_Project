using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[4];
    public GameObject changeflower;

    void Start()
    {

    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LightCollider")
        {
            StartCoroutine("ChangeSprite");
        }
    }

    IEnumerator ChangeSprite()
    {
        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1f);
            changeflower.GetComponent<SpriteRenderer>().sprite = sprites[i];
        }
    }
}
