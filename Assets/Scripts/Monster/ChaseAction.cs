using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[Monster] to [Target] with [Agent]", category: "Action", id: "e99099f720c3b4dc3509f5ab57858565")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Agent.Value.SetDestination(Target.Value.transform.position);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

