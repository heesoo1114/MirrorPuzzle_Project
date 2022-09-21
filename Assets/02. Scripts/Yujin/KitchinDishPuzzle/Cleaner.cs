using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField]
    private GameObject spriteMask;

    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        if(pressed)
        {
            GameObject obj = Instantiate(spriteMask, pos, Quaternion.identity);
            obj.transform.parent = GameObject.Find("Cleaner").transform;
        }
        if (Input.GetMouseButtonDown(0))
            pressed = true;
        else if(Input.GetMouseButtonUp(0))
        {
            pressed = false; 
        }
    }
}
