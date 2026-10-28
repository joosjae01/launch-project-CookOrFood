using UnityEngine;

public class DevilEventStage : EventStageBase
{
    [SerializeField] private Devil _devil;
    
    protected override void EventStageEnter()
    {
        ExitPortal.gameObject.SetActive(false);
        _devil.gameObject.SetActive(true);
        _devil.OnClear += SpawnPortal;
    }

    protected override void EventStageExit()
    {
        _devil.OnClear -= SpawnPortal;
    }

    protected override void SpawnPortal()
    {
        _devil.gameObject.SetActive(false);
        ExitPortal.gameObject.SetActive(true); 
    }
}
