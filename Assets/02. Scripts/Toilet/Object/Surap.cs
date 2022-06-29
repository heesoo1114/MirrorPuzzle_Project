using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surap : MonoBehaviour
{

    

    public GameObject crackFL;
    public GameObject whollyFL;

    

    public void crack()
    {
        crackFL.SetActive(true);
        whollyFL.SetActive(false);
    }

    
}
