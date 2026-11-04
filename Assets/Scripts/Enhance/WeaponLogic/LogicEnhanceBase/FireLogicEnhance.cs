using UnityEngine;

public abstract class FireLogicEnhance : EnhanceBase
{
    public abstract void Fire(Transform muzzlePoint, bool isSecond);
    protected void SetSecondCreated(IPoolable poolable)
    {
        poolable.GameObject.GetComponent<ProjectileController>().ActiveSecondCreated();
    }
}
