using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerandaPuzzle : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[4];
    public GameObject changeflower;
    public GameObject hallwayLetter;

    [SerializeField]
    private bool isChangeing;
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LightCollider")
        {
            StartCoroutine("ChangeSprite");
        }
    }

    IEnumerator ChangeSprite()
    {
        if(isChangeing)
        {
            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(1f);
                changeflower.GetComponent<SpriteRenderer>().sprite = sprites[i];
            }
            isChangeing = false;

            hallwayLetter.SetActive(true);
        }
    }
}
