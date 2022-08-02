using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrawer : MonoBehaviour
{
    public Sprite Open;
    public Sprite Close;

    private SpriteRenderer _sprite = null;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void MirrorClose()
    {
         _sprite.sprite = Close;
    }

    public void NowOpen()
    {
        _sprite.sprite = Open;
    }

}
