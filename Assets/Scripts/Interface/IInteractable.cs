using UnityEngine;

public interface IInteractable
{
    public GameObject GameObject { get; }
    
    public void StartEvent();

    public void EndEvent();
}
