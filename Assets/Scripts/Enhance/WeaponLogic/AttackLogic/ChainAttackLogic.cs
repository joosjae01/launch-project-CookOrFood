using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChainLightningEnhance", menuName = "Scriptable Objects/Enhance/Attack/ChainLightningEnhance")]
public class ChainAttackLogic : AttackLogicEnhance
{
    [SerializeField] private float _radius;
    [SerializeField] private float _interval;
    [SerializeField] private float _damageRate;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private DamageType _damageType;

    public override void Attack(IDamageable damageable, WeaponData weaponData)
    {
        CheckHashSet(weaponData);
        weaponData.CurrentTargets[_damageType].Add(damageable);
        ChainLightning(damageable, weaponData);
    }

    private void ChainLightning(IDamageable target, WeaponData weaponData)
    {
        IDamageable temp = null;
        IDamageable nearest = null;
        Collider[] other = Physics.OverlapSphere(target.GameObject.transform.position, _radius, _enemyLayer);

        float minDist = int.MaxValue;

        for(int i = 0; i < other.Length; i++)
        {
            other[i].TryGetComponent<IDamageable>(out temp);
            if (temp == null) continue;
            if (weaponData.CurrentTargets[_damageType].Contains(temp)) continue;

            float currDist = Vector3.Distance(target.GameObject.transform.position, temp.GameObject.transform.position);

            if(Mathf.Min(minDist, currDist) == currDist)
            {
                minDist = currDist;
                nearest = temp;
            }
        }
        
        if(nearest != null)
        {
            //TODO : 이펙트 기능 추가
            weaponData.CurrentTargets[_damageType].Add(nearest);
            ChainLightning(nearest, weaponData);
        }
        else
        {
            foreach (IDamageable enemy in weaponData.CurrentTargets[_damageType])
            {
                enemy.TakeDamage(weaponData.AttackValue * _damageRate);
            }

            weaponData.CurrentTargets[_damageType].Clear();
        }
    }

    private void CheckHashSet(WeaponData weaponData)
    {
        if (!weaponData.CurrentTargets.ContainsKey(_damageType))
        {
            HashSet<IDamageable> damageableSet = new();
            weaponData.CurrentTargets.Add(_damageType, damageableSet);
        }
    }
}
