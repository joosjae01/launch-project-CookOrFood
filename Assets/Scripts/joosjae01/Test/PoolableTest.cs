using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PoolableTest : MonoBehaviour, IPoolable, IDamageable
{
    public GameObject GameObject { get => gameObject; }
    public ObjectPool Source { get; set; }

    private void OnEnable()
    {
        StartCoroutine(RetrunRoutine());
    }

    private IEnumerator RetrunRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        Source.Push(this);
    }

    public void TakeDamage(float damage)
    {

    }
}
