using UnityEngine;
using Random = UnityEngine.Random;

public class TutorialStage : CombatStageBase
{ 
    public override StageType StageType { get => StageType.Tutorial; }
    
    protected override void CombatStageEnter()
    {
        SpawnMonster();
    }

    protected override void CombatStageExit()
    {
       
    }

    protected override void SpawnMonster()
    {
        for (int i = 0; i < MonsterSpawnPoints.Length; i++)
        {
            int rand = Random.Range(0, MonsterList.Count);
            MonsterType type = (MonsterType)rand;
            
            Monster = PoolManager.Instance.Take(type);

            if (!Monster.GameObject.TryGetComponent(out MonsterController monster)) return;

            monster.transform.position = MonsterSpawnPoints[i].position;
            monster.gameObject.SetActive(true);
            monster.Data.OnKilled += MonsterDead;
            RemainMonsterList.Add(monster);
        }
    }

    protected override void MonsterDead(MonsterController monster)
    {
        RemainMonsterList.Remove(monster);

        if (RemainMonsterList.Count == 0)
        {
            ClearStage();
        }
    }
}
