using UnityEngine;
using System;
using Unity.Behavior;
using Action = System.Action;

public class MonsterData : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _coolDown;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackCoolTime;
    
    [HideInInspector] public ObservableProperty<float> CurrentHealth;
    public Action<MonsterController> OnKilled;
    public bool IsDead;
    
    [field: SerializeField] public float MaxHealth { get; private set; }
    
    public string Name => _name;
    public float Damage => _damage;
    public float Speed => _speed;
    public float CoolDown => _coolDown;
    public float AttackRange => _attackRange;
    public float AttackCoolTime => _attackCoolTime;


    private BehaviorGraphAgent agent;
    private void Awake()
    {
        agent = GetComponent<BehaviorGraphAgent>();
    }

    private void Start()
    {
        agent.BlackboardReference.SetVariableValue("attackRange", _attackRange);
        agent.BlackboardReference.SetVariableValue("moveSpeed", _speed);
        agent.BlackboardReference.SetVariableValue("attackCoolTime", _attackCoolTime);
    }
}
