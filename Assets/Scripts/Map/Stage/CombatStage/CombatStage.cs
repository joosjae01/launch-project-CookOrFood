using UnityEngine;

public class CombatStage : CombatStageBase
{
    public override StageType StageType { get => StageType.Combat; }
    
    protected override void CombatStageEnter()
    {
        ExitPortal.gameObject.SetActive(false); 
    }

    protected override void CombatStageExit()
    {
        
    }
}
