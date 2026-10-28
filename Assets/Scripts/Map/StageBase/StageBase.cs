using System;
using UnityEngine;

public abstract class StageBase : MonoBehaviour
{
    public abstract StageType StageType { get;}
    public Transform PlayerSpawnPoint;
    public ExitPortal ExitPortal;
    
    public bool IsClear { get; protected set; }
    
    public void ResetStage()
    {
        IsClear = false;
    }

    public void ClearStage()
    {
        if (IsClear) return;

        IsClear = true;
        ExitPortal.gameObject.SetActive(true);
    }

    public abstract void Enter();

    public abstract void Exit();
}
