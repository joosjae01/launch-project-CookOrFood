using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "TargettingPlayer", story: "[Monster] Look At [Player] For [Seconds]", category: "Action", id: "aa203333ab5c5c937db5c7062b89301c")]
public partial class TargettingPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<float> Seconds;
    private float elapsedSeconds;

    protected override Status OnStart()
    {
        Player.Value = GameManager.Instance.MainPlayer.gameObject;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Monster.Value.transform.LookAt(Player.Value.transform);
        elapsedSeconds += Time.deltaTime;
        if (elapsedSeconds >= Seconds.Value)
        {
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
        elapsedSeconds = 0;
    }
}

