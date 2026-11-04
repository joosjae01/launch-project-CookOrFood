using UnityEngine;

[CreateAssetMenu(fileName = "SplitLogicEnhance", menuName = "Scriptable Objects/Enhance/Block/SplitLogicEnhance")]
public sealed class SplitLogic : BlockLogicEnhance
{
    [SerializeField] private BasicFireLogic _basicFire;
    [SerializeField] private float _offSet;

    public override void Block(Transform hit)
    {
        hit.position = hit.position + Vector3.back * _offSet;

        hit.Rotate(Vector3.up, 90.0f);
        _basicFire.Fire(hit, true);

        hit.Rotate(Vector3.up, -180.0f);
        _basicFire.Fire(hit, true);
    }
}
