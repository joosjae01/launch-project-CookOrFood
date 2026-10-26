using UnityEngine;

public interface ICollectable
{
    public string Name { get; set; }
    public bool CanCollect {  get; set; }
    public float DropRate {  get; set; }
    public PoolableType Type { get; set; }

    public void Collect();
    public void CheckCanCollect();
}
