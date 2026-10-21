using UnityEngine;

public interface IDamageable
{
    public GameObject GameObject { get; set; }
    public void TakeDamage(float damage);
}
