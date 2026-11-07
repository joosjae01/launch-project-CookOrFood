using System.Collections.Generic;
using UnityEngine;

public abstract class CombatStageBase : StageBase
{
    protected IPoolable Monster;
    protected List<GameObject> MonsterList = new();
    [SerializeField] protected List<MonsterBase> RemainMonsterList = new();
    
    public Transform[] MonsterSpawnPoints;
    public override StageType StageType { get; }

    private void Awake()
    {
        MonsterList = StageManager.Instance.GetMonsterList().MonsterList;
    }

    protected abstract void CombatStageEnter();
    protected abstract void CombatStageExit();
    protected abstract void SpawnMonster();
    protected abstract void BindMonsterDeadEvent();
    protected abstract void UnBindMonsterDeadEvent();
    
    public override void Enter() => CombatStageEnter();

    public override void Exit() => CombatStageExit();

}
