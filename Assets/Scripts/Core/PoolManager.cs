using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonBehaviour<PoolManager>
{
    [SerializeField] private ObjectPool _poolPrefab;
    [SerializeField] private List<PoolData> _poolData = new();
    [SerializeField] private List<MonsterPoolData> _monsterPoolData = new();

    private Dictionary<PoolableType, ObjectPool> _pool = new();
    private Dictionary<MonsterType, ObjectPool> _monsterPool = new();

    private void Awake() => SetSingleton();
    private void Start() => CreatePool();

    private void CreatePool()
    {
        for(int i = 0; i < _poolData.Count; i++)
        {
            _pool[_poolData[i].Type] = Instantiate(_poolPrefab, transform);
            _pool[_poolData[i].Type].name = _poolData[i].Type.ToString();
            _pool[_poolData[i].Type].Init(_poolData[i].Size, _poolData[i].Prefab, _pool[_poolData[i].Type].transform);
        }

        for (int i = 0; i < _monsterPoolData.Count; i++)
        {
            _monsterPool[_monsterPoolData[i].Type] = Instantiate(_poolPrefab, transform);
            _monsterPool[_monsterPoolData[i].Type].name = _monsterPoolData[i].Type.ToString();
            _monsterPool[_monsterPoolData[i].Type].Init(
                _monsterPoolData[i].Size,
                _monsterPoolData[i].Prefab,
                _monsterPool[_monsterPoolData[i].Type].transform
                );
        }
    }

    public IPoolable Take(PoolableType type)
    {
        if (!_pool.ContainsKey(type)) return null;

        return _pool[type].Take();
    }

    public IPoolable Take(MonsterType type)
    {
        if (!_monsterPool.ContainsKey(type)) return null;
        
        return _monsterPool[type].Take();
    }
}
