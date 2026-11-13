using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour,IPoolable,IDamageable
{
    [field: Header("몬스터 타입")]
    [field: SerializeField] public MonsterType Type { get; set; }
    
    [Header("몬스터 공격 타입")]
    [SerializeField] private AttackBase _attackType;
    [SerializeField] private Animator _animator;
    
    protected PlayerController _player;
    private BehaviorGraphAgent _behaviorAgent;
    protected NavMeshAgent _monsterAgent;
    protected Rigidbody _rigidbody;
    
    public MonsterData Data { get; private set; }
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
        if (Data == null) Data = GetComponent<MonsterData>();
        _behaviorAgent = GetComponent<BehaviorGraphAgent>();
    }

    private void Init()
    {
        _player = GameManager.Instance.CurrentPlayer;
        _behaviorAgent.SetVariableValue("player", _player.transform);
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
