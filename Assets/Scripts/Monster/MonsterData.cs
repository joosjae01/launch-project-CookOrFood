using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MonsterData", menuName = "ScriptableObjects/MonsterData")]
public class MonsterData : ScriptableObject
{
    public string Name;
    public float Damage;
    public float Speed;
    public float CoolDown;
    
    public ObservableProperty<float> Health;
    public Action<MonsterData> OnKilled;
}
