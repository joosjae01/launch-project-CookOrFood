using UnityEngine;

public abstract class CombatStageBase : StageBase
{
    public override StageType StageType { get; }

    public Transform[] MonsterSpawnPoints;

    protected abstract void CombatStageEnter();
    protected abstract void CombatStageExit();

    public override void Enter() => CombatStageEnter();

    public override void Exit() => CombatStageExit();

}
