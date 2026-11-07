using UnityEngine;
using System;

public class MonsterData : MonoBehaviour
{
    public string Name;
    public float Damage;
    public float Speed;
    public float CoolDown;
    public float AttackRange;
    public bool IsDead;
    
    public float MaxHealth { get; private set; }
    public ObservableProperty<float> CurrentHealth;
    public Action<MonsterData> OnKilled;
}
