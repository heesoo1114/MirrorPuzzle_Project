using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPosition : MonoBehaviour
{
    [SerializeField] private Vector3 realPos;
    [SerializeField] private Vector3 mirrorPos;

    private void Update()
    {
        if (GameManager.Inst.WorldType == WorldType.RealWorld)
            transform.localPosition = realPos;
        else if (GameManager.Inst.WorldType == WorldType.MirrorWorld)
            transform.localPosition = mirrorPos;
    }
}
