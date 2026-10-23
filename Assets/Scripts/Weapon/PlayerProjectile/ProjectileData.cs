using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Scriptable Objects/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    [Header("투사체 이동 속도")]
    public float MoveSpeed;

    [Header("투사체 생존 시간")]
    public float LifeTime;

    public event Action OnFired;
    public event Action OnMoved;
    public event Action OnBlocked;
    public event Action<IDamageable, WeaponData> OnAttacked;

    public void Fire() => OnFired?.Invoke();
    public void Move() => OnMoved?.Invoke();
    public void Block() => OnBlocked?.Invoke();
    public void Attack(IDamageable damageable, WeaponData weaponData) => OnAttacked?.Invoke(damageable, weaponData);
    
    public void Init()
    {
        OnFired = null;
        OnMoved = null;
        OnBlocked = null;
        OnAttacked = null;
    }
}
