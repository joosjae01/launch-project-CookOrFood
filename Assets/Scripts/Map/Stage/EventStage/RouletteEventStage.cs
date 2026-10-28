using UnityEngine;

public class RouletteEventStage : EventStageBase
{
    [SerializeField] private Roulette _roulette;
    
    protected override void EventStageEnter()
    {
        ExitPortal.gameObject.SetActive(false); 
        _roulette.gameObject.SetActive(true);
        _roulette.OnClear += SpawnPortal;
    }

    protected override void EventStageExit()
    {
        _roulette.OnClear -= SpawnPortal;
    }

    protected override void SpawnPortal()
    {
        _roulette.gameObject.SetActive(false);
        ExitPortal.gameObject.SetActive(true);
    }
}
