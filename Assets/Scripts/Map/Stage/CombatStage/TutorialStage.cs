using System;
using UnityEngine;

public class TutorialStage : CombatStageBase
{
    private IPoolable _monster;
    
    public override StageType StageType { get => StageType.Tutorial; }
    
    protected override void CombatStageEnter()
    {
        ExitPortal.gameObject.SetActive(false);
        
        SpawnMonster();
    }

    protected override void CombatStageExit()
    {
        
    }

    protected override void SpawnMonster()
    {
        for (int i = 0; i < MonsterSpawnPoints.Length; i++)
        {
            GameObject obj = Instantiate(
                MonsterList[0],
                MonsterSpawnPoints[i].position,
                MonsterList[0].transform.rotation);
            obj.SetActive(true);
        }
        
    }
}
