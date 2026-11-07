using System;
using UnityEngine;

[Serializable]
public struct MonsterPoolData
{
    [Header("소환할 몬스터")]
    public MonsterType Type;
    [Header("소환할 개수")]
    public int Size;
    [Header("소환할 프리팹")]
    public GameObject Prefab;
}