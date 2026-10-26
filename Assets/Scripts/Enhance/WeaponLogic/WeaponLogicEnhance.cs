using UnityEngine;

public abstract class WeaponLogicEnhance : EnhanceBase
{
    public abstract void Fire(ProjectileController projectile);
    public abstract void Move(ProjectileController projectile, float moveSpeed);
    public abstract void Attack(IDamageable damageable, WeaponData weaponData);
    public abstract void Block();
}