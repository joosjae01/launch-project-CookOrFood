using UnityEngine;

public class TestDamageable : MonoBehaviour, IDamageable
{
    public GameObject GameObject { get => gameObject; }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{damage} 피해 입음");
    }
}
