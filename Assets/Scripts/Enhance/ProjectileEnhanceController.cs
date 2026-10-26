using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnhanceController : MonoBehaviour
{
    [Header("투사체 생성 로직")]
    [SerializeField] private List<FireLogicEnhance> _fireEnhanceList = new();

    [Header("투사체 움직임 로직")]
    [SerializeField] private List<MoveLogicEnhance> _moveEnhanceList = new();

    [Header("투사체 공격 로직")]
    [SerializeField] private List<AttackLogicEnhance> _attackEnhanceList = new();

    [Header("투사체 벽 충돌 로직")]
    [SerializeField] private List<BlockLogicEnhance> _blockEnhanceList = new();

    [SerializeField] private ProjectileData _projectileData;

    public void AddFireEnhace(int index)
    {
        _projectileData.OnFired.AddListener(_fireEnhanceList[index].Fire);
        EnhanceManager.Instance.AddEnhance(_fireEnhanceList[index]);
    }

    public void AddMoveEnhance(int index)
    {
        _projectileData.OnMoved.RemoveAllListeners();
        _projectileData.OnMoved.AddListener(_moveEnhanceList[index].Move);
        EnhanceManager.Instance.AddEnhance(_moveEnhanceList[index]);
    }

    public void AddAttackEnhance(int index)
    {
        _projectileData.OnAttacked.AddListener(_attackEnhanceList[index].Attack);
        EnhanceManager.Instance.AddEnhance(_attackEnhanceList[index]);
    }

    public void AddBlockEnhance(int index)
    {
        _projectileData.OnBlocked.AddListener(_blockEnhanceList[index].Block);
        EnhanceManager.Instance.AddEnhance(_blockEnhanceList[index]);
    }
}
