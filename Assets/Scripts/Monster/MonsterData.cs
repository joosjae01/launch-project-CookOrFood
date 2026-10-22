using UnityEngine;
using System;

public class MonsterData : MonoBehaviour
{
    [field : SerializeField] public string Name { get; private set; }
    [field : SerializeField] public float Damage { get; private set; }
    [field : SerializeField] public float Speed { get; private set; }
    [field : SerializeField] public float CoolDown { get; private set; }
    
    public ObservableProperty<float> Health;
    public Action<MonsterData> OnKilled;
}
