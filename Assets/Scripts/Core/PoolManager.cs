using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonBehaviour<PoolManager>
{
    [SerializeField] List<PoolData> _poolData = new();
    
    public Dictionary<PoolableType, ObjectPool> Pool = new();

    private void Awake() => SetSingleton();
    private void Start() => CreatePool();

    private void CreatePool()
    {
        for(int i = 0; i < _poolData.Count; i++)
        {
            ObjectPool objectPool = new();
            objectPool.Init(_poolData[i].Size, _poolData[i].Prefab, transform);
            Pool[_poolData[i].Type] = objectPool;
        }
    }
}
