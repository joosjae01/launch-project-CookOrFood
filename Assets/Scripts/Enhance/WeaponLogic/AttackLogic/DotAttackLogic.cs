using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DotLogicEnhance", menuName = "Scriptable Objects/Enhance/Attack/DotLogicEnhance")]
public sealed class DotAttackLogic : AttackLogicEnhance
{
    [SerializeField] private float _damage;
    [SerializeField] private float _duration;
    [SerializeField] private float _interval;
    [SerializeField] private DamageType _damageType;
    private WaitForSeconds _waitForInterval;

    public override void Attack(IDamageable damageable, WeaponData weaponData)
    {
        CheckHashSet(weaponData);
        if (weaponData.CurrentTargets[_damageType].Contains(damageable)) return;
        weaponData.GetComponent<MonoBehaviour>().StartCoroutine(DotRoutine(damageable, weaponData));
    }

    private IEnumerator DotRoutine(IDamageable target, WeaponData weaponData)
    {
        _waitForInterval = new WaitForSeconds(_interval);
        weaponData.CurrentTargets[_damageType].Add(target);

        float elapsed = 0;

        while (elapsed < _duration)
        {
            target.TakeDamage(_damage);
            yield return _waitForInterval;
            elapsed += _interval;
        }

        weaponData.CurrentTargets[_damageType].Remove(target);
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