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
    private float _elapsedTime;
    private float _targetDistance;
    private float _coolCount;
    private void Awake() => CacheComponents();

    private void Update()
    {
        // Debug.Log($" 차징 중 :{_isCharging}, 공격 중 :  {_isAttacking}");
        if (_coolCount > Data.CoolDown)
        {
            Debug.Log(_coolCount);
            DetectPlayer();
        }
        
        
        else if (_isCharging)
        {
            Debug.Log(_coolCount);
            transform.LookAt(_monsterAgent.destination);
        }
        else if (_isAttacking)
        {
            Debug.Log(_coolCount);
            CheckAttack();
        } 
        else Move();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer.Contains(other)) Attack();
        
        StopAttackRoutine();
    }

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
        Debug.Log("공격 시작");
        _attackingRoutine = StartCoroutine(AttackRoutine());
    }

    private void StopAttackRoutine()
    {
        
        if (_attackingRoutine == null) return;
        Debug.Log("공격 종료");
        StopCoroutine(_attackingRoutine);
        Move();
        _elapsedTime = 0;
        _isAttacking = false;
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
        if (_isCharging || _isAttacking) return;
        
        _targetDistance = Vector3.Distance(transform.position,  _player.transform.position);
        
        if (_targetDistance <= Data.AttackRange)
        {
            _coolCount = 0.0f;
            Debug.Log("공격 쿨 시작");
            Debug.Log("플레이어 감지");
            StartAttackRoutine();
        }
    }
}
