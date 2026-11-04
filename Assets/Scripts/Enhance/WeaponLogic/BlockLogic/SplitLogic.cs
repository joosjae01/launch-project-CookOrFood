using UnityEngine;

[CreateAssetMenu(fileName = "SplitLogicEnhance", menuName = "Scriptable Objects/Enhance/Block/SplitLogicEnhance")]
public sealed class SplitLogic : BlockLogicEnhance
{
    [Header("기본 공격 로직")]
    [SerializeField] private BasicFireLogic _basicFire;

    [Header("생성 각도")]
    [SerializeField] private float _angle;

    [Header("생성 오프셋")]
    [SerializeField] private float _offset;

    public override void Block(Transform hit)
    {
        hit.position = hit.position + hit.forward * _offset * -1.0f;

        hit.Rotate(Vector3.up, _angle);
        _basicFire.Fire(hit, true);

        hit.Rotate(Vector3.up, _angle * -2.0f);
        _basicFire.Fire(hit, true);
    }
}
