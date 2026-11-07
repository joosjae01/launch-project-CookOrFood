using Random = UnityEngine.Random;

public class CombatStage : CombatStageBase
{
    public override StageType StageType { get => StageType.Combat; }
    
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

            if (!Monster.GameObject.TryGetComponent(out MonsterBase monsterBase)) return;

            monsterBase.transform.position = MonsterSpawnPoints[i].position;
            monsterBase.gameObject.SetActive(true);
            monsterBase.Data.OnKilled += MonsterDead;
            RemainMonsterList.Add(monsterBase);
        }
    }

    protected override void MonsterDead(MonsterBase monsterBase)
    {
        RemainMonsterList.Remove(monsterBase);

        if (RemainMonsterList.Count == 0)
        {
            ClearStage();
        }
    }
}
