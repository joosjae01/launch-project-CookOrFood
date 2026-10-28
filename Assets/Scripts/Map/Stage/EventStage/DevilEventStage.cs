using UnityEngine;

public class DevilEventStage : EventStageBase
{
    protected override void EventStageEnter()
    {
        ExitPortal.SetActive(false); 
    }

    protected override void EventStageExit()
    {
        
    }
}
