using System;
using UnityEngine;

public class TutorialStage : CombatStageBase
{
    public override StageType StageType { get => StageType.Tutorial; }

    private Collider _collider;

    // ---------- Event Method ----------

    private void Awake() => CacheComponents();

    private void OnTriggerEnter(Collider other)
    {
        
    }

    // ---------------------------------

    private void CacheComponents()
    {
        _collider = GetComponent<Collider>();
    }
    
    protected override void CombatStageEnter()
    {
        
    }

    protected override void CombatStageExit()
    {
        
    }
}
