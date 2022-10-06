using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public Sprite[] sprite = new Sprite[4];

    [SerializeField]
    private bool isCheck;

    void Start()
    {
        SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("04.Sprites/Mins/Flowerpot");
        spriteR.sprite = sprites[0];
    }
}
