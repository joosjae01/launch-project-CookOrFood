using UnityEngine;

public abstract class AttackLogicEnhance : EnhanceBase
{
    public abstract void Attack(IDamageable damageable, WeaponData weaponData);
}
