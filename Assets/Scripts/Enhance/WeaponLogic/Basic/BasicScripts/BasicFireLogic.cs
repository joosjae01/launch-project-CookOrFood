using UnityEngine;

[CreateAssetMenu(fileName = "BasicFireLogic", menuName = "Scriptable Objects/Basic/Fire")]
public class BasicFireLogic : FireLogicEnhance
{
    private IPoolable _temp;
    public override void Fire(Transform muzzlePoint)
    {
        _temp = PoolManager.Instance.Pool[PoolableType.Arrow].Take();
        _temp.GameObject.transform.SetPositionAndRotation(muzzlePoint.position, muzzlePoint.rotation);
    }
}
