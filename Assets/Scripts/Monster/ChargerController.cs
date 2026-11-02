using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ChargerController : MonsterBase
{
    [Header("플레이어 마스크")]
    [SerializeField] private LayerMask _playerLayer;
    
    [Header("공격 유지 시간")]
    [SerializeField] private float _attackTime;
    
    [Header("돌진 준비 시간")]
    [SerializeField] private float _chargeTime;
    
    [Header("돌진 속도")]
    [SerializeField] private float _chargeSpeed;
    
    private Coroutine _attackingRoutine;
    private WaitForSeconds _chargingWait;
    
    private bool _isCharging;
    private bool _isAttacking;
    private bool _isCoolOn => _coolCount >= Data.CoolDown;
    
    private float _elapsedTime;
    private float _targetDistance;
    private float _coolCount;
    // ---------- Event Method ----------
    
    private void Awake() => CacheComponents();

    private void Update()
    {
        DetectPlayer();
        Debug.Log($" 돌진 준비 중인가 : {_isCharging}, 공격 중 인가 : {_isAttacking}, 쿨 돌았나 : {_isCoolOn}");
        
        if (_isCharging) transform.LookAt(_player.transform);
        else if (_isAttacking) CheckAttack();
        else Move();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer.Contains(other)) Attack();
        
        StopAttackRoutine();
    }
    
    // ----------------------------------

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _monsterAgent = GetComponent<NavMeshAgent>();
        
        _player = GameManager.Instance.CurrentPlayer;
        _chargingWait = new WaitForSeconds(_chargeTime);
    }

    private IEnumerator AttackRoutine()
    {
        StopMove();
        _isCharging = true;
        yield return _chargingWait;
        _isCharging = false;
        _isAttacking = true;
    }

    private void CheckAttack()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _attackTime)
        {
            StopAttackRoutine();
        }
        transform.Translate(Vector3.forward * _chargeSpeed * Time.deltaTime);
    }

    private void StartAttackRoutine()
    {
        if(_attackingRoutine != null) return;
        _attackingRoutine = StartCoroutine(AttackRoutine());
    }

    private void StopAttackRoutine()
    {
        if (_attackingRoutine == null) return;
        Debug.Log("공격 종료");
        StopCoroutine(_attackingRoutine);
        Move();
        _coolCount = 0;
        _elapsedTime = 0;
        _isAttacking = false;
        _isCharging = false;
        _attackingRoutine = null;
    }
    
    public override void Attack()
    {
        if (_isAttacking)
        {
            _player.TakeDamage(Data.Damage * 1.5f);
        }
        else
        {
            _player.TakeDamage(Data.Damage);    
        }
    }

    public override void Move()
    {
        if (_monsterAgent !=null && _monsterAgent.isStopped)
        {
            _monsterAgent.isStopped = false;
        }
        _coolCount += Time.deltaTime;
        _monsterAgent.SetDestination(_player.transform.position);
    }

    public override void DetectPlayer()
    {
        if (_isCharging || _isAttacking || !_isCoolOn) return;
        
        _targetDistance = Vector3.Distance(transform.position, _player.transform.position);
        
        if (_targetDistance <= Data.AttackRange)
        {
            StartAttackRoutine();
        }
    }
}
