using UnityEngine;

public class RangedAttack : AttackBase
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _muzzlePoint;
    
    public override void StartAttack()
    {
        Instantiate(_projectilePrefab, _muzzlePoint.position, _muzzlePoint.rotation);
    }
}
