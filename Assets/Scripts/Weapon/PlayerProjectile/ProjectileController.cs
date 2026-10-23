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

    private IDamageable _target;

    public GameObject GameObject { get => gameObject;}
    public ObjectPool Source { get; set; }

    private void Start() => _projectileData.Fire(gameObject);
    private void FixedUpdate() => _projectileData.Move(gameObject, _projectileData.MoveSpeed);
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
