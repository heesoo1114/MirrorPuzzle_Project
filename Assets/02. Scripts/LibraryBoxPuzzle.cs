using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryBoxPuzzle : MonoBehaviour
{
    public Vector3 boxSize = new Vector3(3f, 3f, 3f);

    public Collider2D[] colliders;

    private void Update()
    {
        Debug.Log(Physics2D.OverlapBoxNonAlloc(transform.position, boxSize, 0, colliders));
    }
    void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, boxSize);
    }
}
