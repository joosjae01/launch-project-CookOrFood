using UnityEngine;

public interface IPoolable
{
    public GameObject GameObject { get; set; }
    public ObjectPool Source { get; set; }
    public void ReturnToPool();
}
