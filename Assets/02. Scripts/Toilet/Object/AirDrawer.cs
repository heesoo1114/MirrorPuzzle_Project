using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrawer : MonoBehaviour
{
    public Sprite Open;
    public Sprite Close;
    private bool isClose = false;

    private SpriteRenderer _sprite = null;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void OpenClose()
    {
        /*Close.SetActive(false);
        Open.SetActive(true);*/

        if(isClose == true)
        {
            _sprite.sprite = Close;
            isClose = false;
        }
        else if(isClose == false)
        {
            _sprite.sprite = Open;
            isClose = true;
        }
    }

}
