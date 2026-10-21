using System;
using UnityEngine;

public abstract class StageBase : MonoBehaviour
{
    public bool IsClear { get; protected set; }

    protected event Action OnClear;

    public void ResetStage()
    {
        IsClear = false;
    }

    public abstract void Enter();

    public abstract void Exit();
}
