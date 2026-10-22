using UnityEngine;

public abstract class EventStageBase : StageBase
{
    public override StageType StageType { get => StageType.Event; }
    
    protected abstract void EventStageEnter();
    protected abstract void EventStageExit();

    public override void Enter() => EventStageEnter();
    
    public override void Exit() => EventStageExit();
}
