using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PoolableTest : MonoBehaviour, IPoolable
{
    [SerializeField] private InputActionReference _spaceInput;
    public GameObject GameObject { get; set; }
    public ObjectPool Source { get; set; }

    private void Awake()
    {
        GameObject = gameObject;
    }

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
}
