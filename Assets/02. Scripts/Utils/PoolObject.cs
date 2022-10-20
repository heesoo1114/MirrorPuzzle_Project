using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public SoundPlayer sound;

    void Start()
    {
        PoolManager.Instance = new PoolManager(transform);
        PoolManager.Instance.CreatePool(sound);
    }
}
