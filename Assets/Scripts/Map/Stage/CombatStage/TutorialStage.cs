using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TutorialStage : CombatStageBase
{
    private int _remainMonsterCount; 
        
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
            int rand = Random.Range(0, Enum.GetValues(typeof(MonsterType)).Length);
            MonsterType type = (MonsterType)rand;
            
            Monster = PoolManager.Instance.Take(type);

            if (!Monster.GameObject.TryGetComponent(out MonsterBase monsterBase))
            {
                Debug.Log("MonsterBase 없음");
                return;
            }

            monsterBase.transform.position = MonsterSpawnPoints[i].position;
            monsterBase.gameObject.SetActive(true);
            RemainMonsterList.Add(monsterBase);
            _remainMonsterCount++;
        }
    }

    protected override void BindMonsterDeadEvent()
    {
        
    }

    protected override void UnBindMonsterDeadEvent()
    {
        
    }
}
