using UnityEngine;

public class RangedAttack : AttackBase
{
    [SerializeField] private MonsterProjectile _projectilePrefab;
    [SerializeField] private Transform _muzzlePoint;
    
    private IPoolable _temp;
    
    public override void StartAttack()
    {
        _temp = PoolManager.Instance.Take(_projectilePrefab.PoolableType);
        _temp.GameObject.transform.position = _muzzlePoint.position;
        _temp.GameObject.transform.rotation = _muzzlePoint.rotation;

        if (!_temp.GameObject.TryGetComponent(out MonsterProjectile projectile)) return;
        
        projectile.Damage = _monsterData.Damage;
    }
}
