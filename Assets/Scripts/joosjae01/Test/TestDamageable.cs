using UnityEngine;

public class TestDamageable : MonoBehaviour, IDamageable
{
    public void TakeDamage(float damage)
    {
        Debug.Log($"{damage} 피해 입음");
    }
}
