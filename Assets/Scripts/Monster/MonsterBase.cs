using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterBase : MonoBehaviour, IPoolable, IDamageable
{
    public MonsterData Data;
    protected NavMeshAgent _monsterAgent;
    protected Rigidbody _rigidbody;
    
    public GameObject GameObject { get; set; }
    public ObjectPool Source { get; set; }

    public void ReturnToPool()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Data.Health.Value -= damage;
    }
    
    public abstract void Attack(Transform target);
    
    public abstract void Move(Transform target);
}
