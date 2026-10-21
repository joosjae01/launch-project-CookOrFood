using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonBehaviour<PoolManager>
{
    [SerializeField] private List<string> _prefabName = new();
    [SerializeField] private List<int> _size = new();
    [SerializeField] private List<GameObject> _prefab = new();
    
    public Dictionary<string, ObjectPool> Pool = new();

    private void Awake() => SetSingleton();
    private void Start() => CreatePool();

    private void CreatePool()
    {
        for(int i = 0; i < _prefab.Count; i++)
        {
            ObjectPool objectPool = new();
            objectPool.Init(_size[i], _prefab[i], transform);
            Pool[_prefabName[i]] = objectPool;
        }
    }
}
