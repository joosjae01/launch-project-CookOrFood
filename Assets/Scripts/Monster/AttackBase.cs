using System;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    [SerializeField] protected PlayerController _targetPlayer;
    [SerializeField] protected MonsterData _monsterData;
    
    public void Awake()
    {
        _targetPlayer = GameManager.Instance.CurrentPlayer;
        _monsterData = GetComponent<MonsterData>();
    }

    public abstract void StartAttack();
}
