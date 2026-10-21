using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonBehaviour<PoolManager>
{
    [Header("소환할 프리팹 종류")]
    [SerializeField] private List<PoolableType> _prefabType = new();
    [Header("소환할 개수")]
    [SerializeField] private List<int> _size = new();
    [Header("소환할 프리팹")]
    [SerializeField] private List<GameObject> _prefab = new();
    
    public Dictionary<PoolableType, ObjectPool> Pool = new();

    private void Awake() => SetSingleton();
    private void Start() => CreatePool();

    private void CreatePool()
    {
        for(int i = 0; i < _prefab.Count; i++)
        {
            ObjectPool objectPool = new();
            objectPool.Init(_size[i], _prefab[i], transform);
            Pool[_prefabType[i]] = objectPool;
        }
    }
}
