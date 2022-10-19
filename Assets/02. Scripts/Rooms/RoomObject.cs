using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
    [SerializeField] private bool _useCollider;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void Active(bool isActive)
    {
        if(_useCollider)
        {
            _collider.enabled = isActive;
        }

        else
        {
            gameObject.SetActive(isActive);
        }
    }
}
