using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Out()
    {
        _image.enabled = true;
    }

    public void In()
    {
        _image.enabled = false;
    }
}
