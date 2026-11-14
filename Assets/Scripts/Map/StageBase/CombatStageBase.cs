using System.Collections.Generic;
using UnityEngine;

public abstract class CombatStageBase : StageBase
{
    protected IPoolable Monster;
    protected List<GameObject> MonsterList = new();
    
    // TODO 몬스터 킬 테스트를 위해 현재 StageBase에 선언, 추후 몬스터 킬 가능시 주석해제, StageBase 변수 삭제
    // public List<monsterController> RemainMonsterList = new();
    
    public Transform[] MonsterSpawnPoints;
    public override StageType StageType { get; }

    private void OnEnable()
    {
        MonsterList = StageManager.Instance.GetMonsterList().MonsterList;
    }

    protected abstract void CombatStageEnter();
    protected abstract void CombatStageExit();
    protected abstract void SpawnMonster();
    protected abstract void MonsterDead(MonsterController monster);
    
    public override void Enter() => CombatStageEnter();

    public override void Exit() => CombatStageExit();

}
