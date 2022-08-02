using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilmPuzzle : MonoBehaviour
{
    [SerializeField]
    private Animator Shake_anim;

    [SerializeField]
    private Image film_Img;
    [SerializeField]
    private Image img;

    [SerializeField]
    private GameObject hint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Inst.WorldType == WorldType.RealWorld)
        {
            film_Img.gameObject.SetActive(true);
        }
        else
        {
            film_Img.gameObject.SetActive(true);
        }
        hint.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        film_Img.gameObject.SetActive(false);
    }
}
