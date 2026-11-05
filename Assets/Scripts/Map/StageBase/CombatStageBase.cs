using UnityEngine;

public abstract class CombatStageBase : StageBase
{
    [Header("Monster Spawn SO")]
    [SerializeField] protected StageSO _monsterSpawnData;
    [field: SerializeField] public MonsterType Type { get; set; }
    
    public Transform[] MonsterSpawnPoints;
    public override StageType StageType { get; }

    protected abstract void CombatStageEnter();
    protected abstract void CombatStageExit();
    protected abstract void SpawnMonster();

    public override void Enter() => CombatStageEnter();

    public override void Exit() => CombatStageExit();

}
