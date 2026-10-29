using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour, IPoolable
{
    [Header("적 레이어")]
    [SerializeField] private LayerMask _enemyMask;

    [Header("벽 레이어")]
    [SerializeField] private LayerMask _wallMask;

    [Header("스크립터블 데이터")]
    [SerializeField] private ProjectileData _projectileData;

    [Header("테스트용 무기 데이터")]
    [SerializeField] private WeaponData _weaponData;


    // TODO : 추후, 가장 근처의 적을 받을 필요 있음.
    [Header("테스트용 적 참조")]
    public MonsterBase TargetMonster;

    private IDamageable _target;

    public GameObject GameObject { get => gameObject;}
    public ObjectPool Source { get; set; }

    private void FixedUpdate() => _projectileData.Move(this, _projectileData.MoveSpeed);
    private void OnTriggerEnter(Collider other)
    {
        CheckEnemy(other);
        CheckWall(other);
    }

    private void CheckEnemy(Collider other)
    {
        if (!_enemyMask.Contains(other)) return;

        other.TryGetComponent<IDamageable>(out _target);
        _projectileData.Attack(_target, _weaponData);
        ReturnToPool();
    }

    private void CheckWall(Collider other)
    {
        if (!_wallMask.Contains(other)) return;

        _projectileData.Block();
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        Source.Push(this);
    }
}
