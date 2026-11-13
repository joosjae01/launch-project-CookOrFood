using System;
using System.Collections;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour, IPoolable
{
    [Header("Pool Type")]
    [field: SerializeField] public PoolableType PoolableType { get; set; }
    
    [Header("Player Layer")]
    [SerializeField] private LayerMask _playerLayerMask;
    
    [Header("Wall Layer")]
    [SerializeField] private LayerMask _wallLayerMask;
    
    [Header("Speed")]
    [SerializeField] private float _projectileSpeed;
    
    [Header("Life Time")]
    [SerializeField] private float _lifeTime;
    
    private Coroutine _returnRoutine;
    private WaitForSeconds _waitForReturn;

    [HideInInspector] public float Damage;
    public GameObject GameObject { get => gameObject; }
    public ObjectPool Source { get; set; }

    // ---------- Event Method ----------

    private void Awake() => CacheComponents();
    
    private void OnEnable()
    {
        StartReturnRoutine();
    }

    private void OnDisable()
    {
        StopReturnRoutine();
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * (_projectileSpeed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayerMask.Contains(other))
        {
            other.GetComponent<IDamageable>().TakeDamage(Damage);
            ReturnToPool();
        }
        else if (_wallLayerMask.Contains(other))
        {
            ReturnToPool();
        }
    }

    // ----------------------------------

    private void CacheComponents()
    {
        _waitForReturn = new WaitForSeconds(_lifeTime);
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
    
    public void ReturnToPool()
    {
        Source.Push(this);
    }
}
