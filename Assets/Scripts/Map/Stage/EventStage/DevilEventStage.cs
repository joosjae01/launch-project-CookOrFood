using UnityEngine;

public class DevilEventStage : EventStageBase
{
    protected override void EventStageEnter()
    {
        ExitPortal.gameObject.SetActive(false); 
    }

    protected override void EventStageExit()
    {
        
    }

    protected override void SpawnPortal()
    {
        
    }
}
