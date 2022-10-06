using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PoolList")]
public class PollingListSO : ScriptableObject
{
    [SerializeField]
    private List<GameObject> poolables;
}
