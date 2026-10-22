using System;
using UnityEngine;

public abstract class StageBase : MonoBehaviour
{
    public Transform PlayerSpawnPoint;
    
    public bool IsClear { get; protected set; }

    public event Action OnExitStage;
    
    public void ResetStage()
    {
        IsClear = false;
    }

    public abstract void Enter();

    public abstract void Exit();
}
