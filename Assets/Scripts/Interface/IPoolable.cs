using UnityEngine;

public interface IPoolable
{
    public GameObject GameObject { get; }
    public ObjectPool Source { get; set; }
    public void ReturnToPool();
}
