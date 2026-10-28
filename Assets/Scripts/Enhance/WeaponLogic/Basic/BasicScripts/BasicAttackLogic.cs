using UnityEngine;

[CreateAssetMenu(fileName = "BasicAttackLogic", menuName = "Scriptable Objects/Basic/Attack")]
public class BasicAttackLogic : AttackLogicEnhance
{
    public override void Attack(IDamageable damageable, WeaponData weaponData)
    {
        damageable.TakeDamage(weaponData.AttackValue);
    }
}
