using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterBase : MonoBehaviour, IPoolable, IDamageable
{
    protected PlayerController _player;
    protected NavMeshAgent _monsterAgent;
    protected Rigidbody _rigidbody;
    
    public MonsterData Data;
    public GameObject GameObject { get => gameObject; }
    public ObjectPool Source { get; set; }

    public void ReturnToPool()
    {
        Source.Push(this);
    }

    public void TakeDamage(float damage)
    {
        Data.Health.Value -= damage;
    }
    
    public abstract void Attack();
    
    public abstract void Move();

    public virtual void StopMove()
    {
        _monsterAgent.isStopped = true;
    }

    public abstract void DetectPlayer();
}
