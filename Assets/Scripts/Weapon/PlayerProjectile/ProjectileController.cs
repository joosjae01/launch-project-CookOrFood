using System.Collections;
using UnityEngine;

public class ProjectileController : MonoBehaviour, IPoolable
{
    [Header("적 레이어")]
    [SerializeField] private LayerMask _enemyMask;

    [Header("벽 레이어")]
    [SerializeField] private LayerMask _wallMask;

    [Header("스크립터블 데이터")]
    [SerializeField] private ProjectileData _projectileData;

    private Coroutine _returnRoutine;
    private WaitForSeconds _waitForReturn;

    private IDamageable _target;
    private bool _isSecondCreated;

    public GameObject GameObject { get => gameObject;}
    public ObjectPool Source { get; set; }
    public MonsterController Target;
    public WeaponData WeaponData;

    private void Awake() => CacheComponents();
    private void Start() => Init();
    private void OnEnable()
    {
        StartReturnRoutine();
        StageManager.Instance.OnExited += ReturnToPool;
    }
    private void OnDisable()
    {
        StopReturnRoutine();
        StageManager.Instance.OnExited -= ReturnToPool;
    }
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
        _projectileData.Attack(_target, WeaponData);
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
        ReturnToPool();
    }

    public void ActiveSecondCreated()
    {
        _isSecondCreated = true;
    }

    public void ReturnToPool()
    {
        StopReturnRoutine();
        Source.Push(this);
        _isSecondCreated = false;
    }

    private void CacheComponents()
    {
        _waitForReturn = new WaitForSeconds(_projectileData.LifeTime);
    }

    private void Init()
    {
        WeaponData = GameManager.Instance.CurrentWeaponData;
    }
}
