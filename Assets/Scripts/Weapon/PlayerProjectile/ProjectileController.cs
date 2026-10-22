using UnityEngine;

public class ProjectileController : MonoBehaviour, IPoolable
{
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private LayerMask _wallMask;
    public GameObject GameObject { get => gameObject;}
    public ObjectPool Source { get; set; }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public void ReturnToPool()
    {
        Source.Push(this);
    }
}
