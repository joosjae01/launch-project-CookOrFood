using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DotLogicEnhance", menuName = "Scriptable Objects/Enhance/Attack/DotLogicEnhance")]
public sealed class DotAttackLogic : AttackLogicEnhance
{
    [Header("대미지 배율")]
    [SerializeField] private float _damageRate;

    [Header("효과 지속 시간")]
    [SerializeField] private float _duration;

    [Header("대미지 주기")]
    [SerializeField] private float _interval;

    [Header("대미지 종류")]
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
            target.TakeDamage(_damageRate * weaponData.AttackValue);
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