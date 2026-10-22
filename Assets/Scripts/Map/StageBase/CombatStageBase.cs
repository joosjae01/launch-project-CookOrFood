using UnityEngine;

public abstract class CombatStageBase : StageBase
{
    public override MapType MapType { get; }

    protected abstract void CombatStageEnter();
    protected abstract void CombatStageExit();

    public override void Enter() => CombatStageEnter();

    public override void Exit() => CombatStageExit();

}
