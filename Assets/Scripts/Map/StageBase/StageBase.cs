using System.Collections.Generic;
using UnityEngine;

public abstract class StageBase : MonoBehaviour
{
    public abstract StageType StageType { get;}
    public Transform PlayerSpawnPoint;
    public ExitPortal ExitPortal;
    
    // TODO 몬스터 킬 테스트를 위해 현재 StageBase에 선언, 추후 몬스터 킬 가능시 변수 삭제
    public List<MonsterController> RemainMonsterList = new();
    
    public void ResetStage()
    {
        ExitPortal.gameObject.SetActive(false);
    }

    public void ClearStage()
    {
        ExitPortal.gameObject.SetActive(true);
    }

    public abstract void Enter();

    public abstract void Exit();
}
