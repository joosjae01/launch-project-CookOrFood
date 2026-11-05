using System;
using UnityEngine;

public class TutorialStage : CombatStageBase
{
    private GameObject _monster;
    
    public override StageType StageType { get => StageType.Tutorial; }

    protected override void CombatStageEnter()
    {
        ExitPortal.gameObject.SetActive(false);   
    }

    protected override void CombatStageExit()
    {
        
    }

    protected override void SpawnMonster()
    {
        //_monsterSpawnData.MonsterList
    }
}
