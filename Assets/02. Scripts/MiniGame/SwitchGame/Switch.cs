using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject onImage;
    [SerializeField] private GameObject offImage;

    public bool isOn = false;

    private void Start()
    {
        if (isOn == true)
        {
            offImage.SetActive(false);
            onImage.SetActive(true);
        }
    }

    public void SwitchOnOff()
    {
        if (isOn == true) // 켜져있으니 꺼야함
        {
            onImage.SetActive(false);
            offImage.SetActive(true);
            isOn = false;
        }
        else if (isOn == false) // 꺼져있으니 켜야함
        {
            offImage.SetActive(false);
            onImage.SetActive(true);
            isOn = true;
        }
    }
}
