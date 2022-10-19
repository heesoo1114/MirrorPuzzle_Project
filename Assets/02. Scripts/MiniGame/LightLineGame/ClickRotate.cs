using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotate : MonoBehaviour
{
    private RotateMirror rotateMirror = null;

    private void Awake()
    {
        rotateMirror = GetComponentInParent<RotateMirror>();
    }

    private void OnMouseDown()
    {
        if (rotateMirror._state == RotateMirror.State.Left)
            rotateMirror._state = RotateMirror.State.Right;
        else if (rotateMirror._state == RotateMirror.State.Right)
            rotateMirror._state = RotateMirror.State.Left;
    }
}
