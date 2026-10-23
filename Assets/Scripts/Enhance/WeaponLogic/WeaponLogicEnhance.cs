using UnityEngine;

[CreateAssetMenu(fileName = "WeaponLogicEnhance", menuName = "Scriptable Objects/WeaponLogicEnhance")]
public abstract class WeaponLogicEnhance : EnhanceBase
{
    [SerializeField] protected Transform _muzzlePoint;
    protected IPoolable _projectile;
    protected Transform _transform;

    public abstract void Fire(GameObject projectile);
    public abstract void Move(GameObject projectile, float moveSpeed);
    public abstract void Attack(IDamageable damageable, WeaponData weaponData);
    public abstract void Block();
}