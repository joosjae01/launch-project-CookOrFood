using UnityEngine;

public class AngelEventStage : EventStageBase
{
    [SerializeField] private Angel _angel;
    
    protected override void EventStageEnter()
    {
        ExitPortal.gameObject.SetActive(false); 
        _angel.gameObject.SetActive(true);
        _angel.OnClear += SpawnPortal;
    }

    protected override void EventStageExit()
    {
        _angel.OnClear -= SpawnPortal;
    }

    protected override void SpawnPortal()
    {
        _angel.gameObject.SetActive(false);
        ExitPortal.gameObject.SetActive(true); 
    }
}
