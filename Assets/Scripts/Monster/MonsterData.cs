using UnityEngine;
using System;

public class MonsterData : MonoBehaviour
{
    private string _name;
    private float _damage;
    private float _speed;
    private float _coolDown;
    private float _attackRange;
    private float _attackCoolTime;
    
    [HideInInspector] public ObservableProperty<float> CurrentHealth;
    public Action<MonsterBase> OnKilled;
    public bool IsDead;
    public float MaxHealth { get; private set; }
    
    public string Name => _name;
    public float Damage => _damage;
    public float Speed => _speed;
    public float CoolDown => _coolDown;
    public float AttackRange => _attackRange;
    public float AttackCoolTime => _attackCoolTime;

}
