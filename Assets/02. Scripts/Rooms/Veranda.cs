using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veranda : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;

    private void Start()
    {
        EventManager.StartListening("ENTER_Veranda", () => blackScreen.SetActive(false));
    }
}
