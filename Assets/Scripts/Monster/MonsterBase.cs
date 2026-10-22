using UnityEngine;

public abstract class MonsterBase : IPoolable, IDamageable
{
    public MonsterData Data;
    
    public GameObject GameObject { get; set; }
    public ObjectPool Source { get; set; }

    public void ReturnToPool()
    {
        
    }

    public void TakeDamage(float damage)
    {
        
    }

    protected abstract void Attack(float damage);
}
