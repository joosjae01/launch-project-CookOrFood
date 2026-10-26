using System.Collections.Generic;
using UnityEngine;

public class TrophySpawner : MonoBehaviour
{
    [SerializeField] private MonsterData _monsterData;
    [SerializeField] private List<GameObject> _trophies = new();

    private IPoolable _temp;
    private ICollectable _collectable;
    private int _randomRange;
    

    private void Awake() => CacheComponent();
    private void OnEnable() => BindEvent();
    private void OnDisable() => UnBindEvent();

    private void SpawnTrophies(MonsterData monsterData)
    {
        foreach(GameObject trophy in _trophies) SpawnTrophy(trophy);
    }

    private void SpawnTrophy(GameObject trophy)
    {
        _randomRange = Random.Range(0, 10);
        _collectable = trophy.GetComponent<ICollectable>();

        if(_randomRange <= _collectable.DropRate * 10)
        {
            _temp = PoolManager.Instance.Pool[_collectable.Type].Take();

            if (_temp == null) return;

            _temp.GameObject.transform.position = transform.position;
        }
    }

    private void BindEvent() => _monsterData.OnKilled += SpawnTrophies;
    private void UnBindEvent() => _monsterData.OnKilled -= SpawnTrophies;
    private void CacheComponent() => _monsterData = GetComponent<MonsterData>();
}
