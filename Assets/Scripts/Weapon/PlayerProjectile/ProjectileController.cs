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

    private IDamageable _target;
    private WeaponData _weaponData;

    public GameObject GameObject { get => gameObject;}
    public ObjectPool Source { get; set; }

    private void Start() => _projectileData.Fire();
    private void FixedUpdate() => _projectileData.Move();
    private void OnTriggerEnter(Collider other) => CheckLayerMask(other);

    private void CheckEnemy(Collider other)
    {
        if (!_enemyMask.Contains(other)) return;

        other.TryGetComponent<IDamageable>(out _target);
        _projectileData.Attack(_target, _weaponData);
    }

    private void CheckWall(Collider other)
    {
        if (!_wallMask.Contains(other)) return;

        _projectileData.Block();
    }

    private void CheckLayerMask(Collider other)
    {
        CheckEnemy(other);
        CheckWall(other);
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        Source.Push(this);
    }
}
