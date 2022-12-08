using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LibraryBoxPuzzle : MonoBehaviour
{
    public LayerMask layer;

    [SerializeField]
    private Transform coliderTransform;

    public UnityEvent OnClearPuzzle;
    bool isPlaying;

    private void Awake()
    {
        isPlaying = (PlayerPrefs.GetInt("LibraryBoxPuzzle") == 1);
        OnClearPuzzle.AddListener(() => { isPlaying = true; });
        if (isPlaying)
            PlayerPrefs.SetInt("LibraryBoxPuzzle", 1);
    }

    private void Update()
    {
        if (isPlaying) return;
        BoxColliderCheck();
    }

    void BoxColliderCheck()
    {
        if (GameManager.Inst.librayChestPuzzleClear)
        {
            Collider2D[] boxCol = Physics2D.OverlapBoxAll(coliderTransform.position, new Vector2(.03f, 6), 0f, layer);

            if (boxCol.Length == 5)
            {
                OnClearPuzzle?.Invoke();
            }
            
        }
    }

#if UNITY_EDITOR

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(coliderTransform.position, new Vector3(.03f, 6, 0));
    }

#endif
}