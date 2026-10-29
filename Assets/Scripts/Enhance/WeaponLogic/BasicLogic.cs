using UnityEngine;

public class BasicLogic : MonoBehaviour
{
    public void BasicMove(ProjectileController projectile, float moveSpeed)
    {
        projectile.transform.Translate(projectile.transform.forward * moveSpeed * Time.deltaTime);
    }

    public void BasicAttack(IDamageable damageable, WeaponData weaponData)
    {
        damageable.TakeDamage(weaponData.AttackValue);
    }

    public void BasicBlock()
    {

    }
}
