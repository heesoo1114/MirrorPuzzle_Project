using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrowFingding : MonoBehaviour
{
    public int count = 0;

    [SerializeField]
    private Image invenImage;

    [SerializeField]
    private SpriteRenderer[] draws;
    

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
        if(GameManager.Inst.coliderState == eColiderState.Locker)
        {
            if (GameManager.Inst.WorldType == WorldType.RealWorld)
            {
                draws[0].gameObject.SetActive(true);
            }
        }
        else if(GameManager.Inst.coliderState == eColiderState.Box)
        {
            if (GameManager.Inst.WorldType == WorldType.RealWorld)
            {
                draws[1].gameObject.SetActive(true);
            }
        }
        else if(GameManager.Inst.coliderState == eColiderState.Table)
        {
            if (GameManager.Inst.WorldType == WorldType.RealWorld)
            {
                draws[2].gameObject.SetActive(true);
            }
        }
        else if (GameManager.Inst.coliderState == eColiderState.Closet)
        {
            if(GameManager.Inst.WorldType == WorldType.RealWorld)
            {
                draws[3].gameObject.SetActive(true);
            }
        }
        else if (GameManager.Inst.coliderState == eColiderState.Bed) 
        {
            if(GameManager.Inst.WorldType == WorldType.RealWorld)
            {
                draws[4].gameObject.SetActive(true);
            }
            else if(GameManager.Inst.WorldType == WorldType.MirrorWorld)
            {
                draws[4].gameObject.transform.localScale = new Vector3(-30, 30, 30);
            }                                                                                                           
        }
    }

    public void ObjectFind()
    {
        count++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("´ê");
            invenImage.gameObject.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            invenImage.gameObject.SetActive(false);
        }

    }

}
