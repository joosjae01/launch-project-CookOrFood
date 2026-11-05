using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatStageBase : StageBase
{
    [field: SerializeField] public MonsterType Type { get; set; }

    [SerializeField] protected List<GameObject> MonsterList = new();
    public Transform[] MonsterSpawnPoints;
    public override StageType StageType { get; }

    private void Awake()
    {
        MonsterList = StageManager.Instance.GetMonsterList().MonsterList;
    }

    protected abstract void CombatStageEnter();
    protected abstract void CombatStageExit();
    protected abstract void SpawnMonster();

    public override void Enter() => CombatStageEnter();

    public override void Exit() => CombatStageExit();

}
