using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPuzzle : InteractionObject
{
    [SerializeField]
    private GameObject Film_spr;
    [SerializeField]
    private GameObject letter;

    public override void InteractionEvent()
    {
        Film_spr.gameObject.SetActive(true);
        letter.gameObject.SetActive(true);
        base.InteractionEvent();
        gameObject.tag = null;
    }

}
