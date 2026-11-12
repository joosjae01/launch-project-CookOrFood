using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[Monster] chase to [Player] with [MoveSpeed]", category: "Action", id: "c761d52142953a4b9db1c9f57ead8da1")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Monster;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    [SerializeReference] public BlackboardVariable<float> MoveSpeed;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        // Vector3 moveDir = (Player.Value.position - Monster.Value.position).normalized;
        Monster.Value.Translate( Monster.Value.forward * MoveSpeed.Value * Time.deltaTime, Space.World);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

