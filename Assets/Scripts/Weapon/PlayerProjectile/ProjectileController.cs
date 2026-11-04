using System;
using System.Collections;
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

    private Coroutine _returnRoutine;
    private WaitForSeconds _waitForReturn;


    // TODO : 추후, 가장 근처의 적을 받을 필요 있음.
    [Header("테스트용 적 참조")]
    public MonsterBase TargetMonster;

    private IDamageable _target;
    private bool _isSecondCreated;

    public GameObject GameObject { get => gameObject;}
    public ObjectPool Source { get; set; }

    private void Start() => Init();
    private void OnEnable() => StartReturnRoutine();
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
        if (_isSecondCreated)
        {
            ReturnToPool();
            return;
        }

        _projectileData.Block(transform);
        ReturnToPool();
    }

    private void StartReturnRoutine()
    {
        if (_returnRoutine != null) return;
        _returnRoutine = StartCoroutine(ReturnRoutine());
    }

    private void StopReturnRoutine()
    {
        if (_returnRoutine == null) return;
        StopCoroutine(_returnRoutine);
        _returnRoutine = null;
    }

    private IEnumerator ReturnRoutine()
    {
        yield return _waitForReturn;
        StopReturnRoutine();
    }



    public void ActiveSecondCreated()
    {
        _isSecondCreated = true;
    }

    public void ReturnToPool()
    {
        Source.Push(this);
        _isSecondCreated = false;
        StopReturnRoutine();
    }

    private void Init()
    {
        _weaponData = GameManager.Instance.CurrentWeaponData;
        _waitForReturn = new WaitForSeconds(_projectileData.LifeTime);
    }
}
