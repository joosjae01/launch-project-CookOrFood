using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TutorialStage : CombatStageBase
{
    public override StageType StageType { get => StageType.Tutorial; }
    
    protected override void CombatStageEnter()
    {
        ExitPortal.gameObject.SetActive(false);
        
        SpawnMonster();
    }

    protected override void CombatStageExit()
    {
        // TODO 추후 최종 몬스터 컨트롤러 or 최상위 스크립트 참조하여 몬스터 데이터 초기화
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
        }
    }
}
