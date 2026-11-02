using UnityEngine;
using System;

public class MonsterData : MonoBehaviour
{
    public string Name;
    public float Damage;
    public float Speed;
    public float CoolDown;
    public float AttackRange;
    
    public ObservableProperty<float> Health;
    public Action<MonsterData> OnKilled;
}
