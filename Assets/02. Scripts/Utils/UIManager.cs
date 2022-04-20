using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image letterImage;

    public void SetActiveLetter(bool isActive)
    {
        letterImage.gameObject.SetActive(isActive);
    }
}
