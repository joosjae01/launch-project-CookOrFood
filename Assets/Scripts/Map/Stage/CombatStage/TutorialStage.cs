using System;
using UnityEngine;

public class TutorialStage : CombatStageBase
{
    private IPoolable _monster;
    
    public override StageType StageType { get => StageType.Tutorial; }
    
    protected override void CombatStageEnter()
    {
        ExitPortal.gameObject.SetActive(false);
        
        for (int i = 0; i < 3; i++)
        {
            SpawnMonster();
        }
    }

    protected override void CombatStageExit()
    {
        
    }

    protected override void SpawnMonster()
    {
        //._monster = PoolManager.Instance.Take(Type);
        
    }
}
