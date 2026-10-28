using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "ChargingAttack",
    story: "[Monster] [Charging] to [Target] with [Status]",
    category: "Action", 
    id: "c9804571ac3d774bf1a4b1b6586a48bd")]
public partial class ChargingAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<Vector3> Charging;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<ChargeMonster> Status;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

