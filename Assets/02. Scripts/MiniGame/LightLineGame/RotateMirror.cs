using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMirror : MonoBehaviour
{
    public enum state
    {
        Left,
        Right
    }

    public state _state;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float rotation = 45f;
            switch (_state)
            {
                case state.Left:
                    rotation = 45f;
                    break;
                case state.Right:
                    rotation = -45f;
                    break;
            }
            collision.transform.Rotate(new Vector3(0, 0, transform.rotation.z + rotation));
        }
    }
}
