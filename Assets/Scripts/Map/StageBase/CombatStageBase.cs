using UnityEngine;

public abstract class CombatStageBase : StageBase
{
    [Header("Monster Spawn SO")]
    [SerializeField] protected StageSO _monsterSpawnData;
    
    public override StageType StageType { get; }

    public Transform[] MonsterSpawnPoints;

    protected abstract void CombatStageEnter();
    protected abstract void CombatStageExit();
    protected abstract void SpawnMonster();

    public override void Enter() => CombatStageEnter();

    public override void Exit() => CombatStageExit();

}
