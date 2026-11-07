using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterBase : MonoBehaviour, IPoolable, IDamageable
{
    protected PlayerController _player;
    protected NavMeshAgent _monsterAgent;
    protected Rigidbody _rigidbody;
    
    public MonsterData Data;
    public GameObject GameObject { get => gameObject; }
    public Transform Transform { get => transform; }
    public ObjectPool Source { get; set; }

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
