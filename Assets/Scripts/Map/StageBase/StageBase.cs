using System;
using UnityEngine;

public abstract class StageBase : MonoBehaviour
{
    public abstract StageType StageType { get;}
    public Transform PlayerSpawnPoint;
    public Transform PortalTransform;

    public bool IsClear { get; protected set; }

    public event Action OnStageClear;
    
    public void ResetStage()
    {
        IsClear = false;
        PortalTransform.gameObject.SetActive(false);
    }

    public abstract void Enter();

    public abstract void Exit();
}
