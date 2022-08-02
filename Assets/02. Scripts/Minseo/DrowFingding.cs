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
