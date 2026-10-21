using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonBehaviour<PoolManager>
{
    private void Awake() => SetSingleton();

    Dictionary<MonsterType, ObjectPool> _monsterPool;
    Dictionary<ProjectileType, ObjectPool> _projectilePool;
    ObjectPool _roomPool;

}
