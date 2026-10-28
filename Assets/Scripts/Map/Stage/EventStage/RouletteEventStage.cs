using UnityEngine;

public class RouletteEventStage : EventStageBase
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
