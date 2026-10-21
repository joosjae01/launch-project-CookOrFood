using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PoolableTest : MonoBehaviour, IPoolable, IDamageable
{
    public GameObject GameObject { get; set; }
    public ObjectPool Source { get; set; }

    private void Awake()
    {
        GameObject = gameObject;
    }

    private void OnEnable()
    {
        StartCoroutine(RetrunRoutine());
        TakeDamage(6.7f);
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
        Debug.Log("대미지 테스트");
    }
}
