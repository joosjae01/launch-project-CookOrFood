using System;
using UnityEngine;

public class TutorialStage : CombatStageBase
{
    public override StageType StageType { get => StageType.Tutorial; }
    
    protected override void CombatStageEnter()
    {
        ExitPortal.gameObject.SetActive(false);   
    }

    protected override void CombatStageExit()
    {
        
    }
}
