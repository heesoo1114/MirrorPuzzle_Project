using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryBoxPuzzle : MonoBehaviour
{
    public LayerMask layer;

    [SerializeField]
    private Transform coliderTransform;
    [SerializeField] 
    private Letter key;

    private void Update()
    {
        BoxColliderCheck();
    }

    void BoxColliderCheck()
    {
        if(GameManager.Inst.librayChestPuzzleClear)
        {
            Collider2D[] boxCol = Physics2D.OverlapBoxAll(
                                  coliderTransform.position, new Vector2(.03f, 6), 0f, layer);

            if (boxCol.Length == 5)
                key.Fallling();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(coliderTransform.position, new Vector3(.03f, 6, 0));

    }
}
