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
        if (isOn == true) // ���������� ������
        {
            onImage.SetActive(false);
            offImage.SetActive(true);
            isOn = false;
        }
        else if (isOn == false) // ���������� �Ѿ���
        {
            offImage.SetActive(false);
            onImage.SetActive(true);
            isOn = true;
        }
    }
}
