using UnityEngine;

[CreateAssetMenu(fileName = "MultiShotLogicEnhance", menuName = "Scriptable Objects/Enhance/Fire/MultiShotLogicEnhance")]
public sealed class MultiShotLogic : FireLogicEnhance
{
    [SerializeField] private float _offset;
    [SerializeField] private int _count;

    private IPoolable _temp;

    public override void Fire(Transform muzzlePoint)
    {
        float first = -(_offset * (_count - 1)) * 0.5f;
        Vector3 right = muzzlePoint.right;
        
        for(int i = 0; i < _count; i++)
        {
            _temp = PoolManager.Instance.Pool[PoolableType.Arrow].Take();
            Vector3 position = muzzlePoint.position + right * (first + _offset * i);
            _temp.GameObject.transform.SetPositionAndRotation(position, muzzlePoint.rotation);
        }
    }
}
