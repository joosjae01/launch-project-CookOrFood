using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Scriptable Objects/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    [Header("투사체 이동 속도")]
    public float MoveSpeed;

    [Header("투사체 생존 시간")]
    public float LifeTime;

    [Header("이동")]
    public UnityEvent<ProjectileController, float> OnMoved;
    [Header("벽과 충돌")]
    public UnityEvent OnBlocked;
    [Header("적과 충돌")]
    public UnityEvent<IDamageable, WeaponData> OnAttacked;

    public void Move(ProjectileController projectile, float speed) => OnMoved?.Invoke(projectile, speed);
    public void Block() => OnBlocked?.Invoke();
    public void Attack(IDamageable damageable, WeaponData weaponData) => OnAttacked?.Invoke(damageable, weaponData);
    
    public void Init()
    {
        OnMoved = null;
        OnBlocked = null;
        OnAttacked = null;
    }
}
