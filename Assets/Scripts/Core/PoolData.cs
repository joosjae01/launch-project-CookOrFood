using System;
using UnityEngine;

[Serializable]
public struct PoolData
{
    [Header("소환할 프리팹 종류")]
    public PoolableType Type;
    [Header("소환할 개수")]
    public int Size;
    [Header("소환할 프리팹")]
    public GameObject Prefab;
}
