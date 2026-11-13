using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterBase : MonoBehaviour, IPoolable, IDamageable
{
    [SerializeField] private AttackBase _attackType;
    [SerializeField] private Animator _animator;
    
    protected PlayerController _player;
    private BehaviorGraphAgent _behaviorAgent;
    protected NavMeshAgent _monsterAgent;
    protected Rigidbody _rigidbody;
    
    public MonsterData Data;
    public GameObject GameObject { get => gameObject; }
    public Transform Transform { get => transform; }
    public ObjectPool Source { get; set; }
    
    // ---------- Event Method ----------
    
    private void Awake() => CacheComponents();

    private void Start() => Init();
    
    // ----------------------------------
    
    private void CacheComponents()
    {
        if (_attackType == null) _attackType = GetComponent<AttackBase>();
        _behaviorAgent = GetComponent<BehaviorGraphAgent>();
    }

    private void Init()
    {
        _behaviorAgent.SetVariableValue("attackType", _attackType);
    }
    
    public void TakeDamage(float damage)
    {
        Data.CurrentHealth.Value -= damage;

        if (Data.CurrentHealth.Value <= 0)
        {
            Dead();
        }
    }
    
    public abstract void DetectPlayer();
    
    public abstract void Attack();
    
    public abstract void Move();

    public virtual void StopMove()
    {
        _monsterAgent.isStopped = true;
    }

    public void Dead()
    {
        Data.OnKilled.Invoke(this);
        Data.IsDead = true;
        
        // TODO 죽는 애니메이션 실행
        
        DataReset();
        ReturnToPool();
    }

    public void DataReset()
    {
        Data.CurrentHealth.Value = Data.MaxHealth;
        Data.IsDead = false;
    }
    
    public void ReturnToPool()
    {
        Source.Push(this);
    }
}
