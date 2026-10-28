using UnityEngine;

public class AngelEventStage : EventStageBase
{
    [SerializeField] private Angel _angel;
    
    protected override void EventStageEnter()
    {
        ExitPortal.SetActive(false); 
        _angel.GetPortal(ExitPortal);
    }

    protected override void EventStageExit()
    {
        
    }
}
