using UnityEngine;

public class RouletteEventStage : EventStageBase
{
    protected override void EventStageEnter()
    {
        ExitPortal.SetActive(false); 
    }

    protected override void EventStageExit()
    {
        
    }
}
