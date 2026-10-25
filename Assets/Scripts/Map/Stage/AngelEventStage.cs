using UnityEngine;

public class AngelEventStage : EventStageBase
{
    protected override void EventStageEnter()
    {
        ExitPortal.SetActive(false); 
    }

    protected override void EventStageExit()
    {
        
    }
}
