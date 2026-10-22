using UnityEngine;

public abstract class EventStageBase : StageBase
{
    public override MapType MapType { get => MapType.Event; }
    
    protected abstract void EventStageEnter();
    protected abstract void EventStageExit();

    public override void Enter() => EventStageEnter();
    
    public override void Exit() => EventStageExit();
}
