using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[Monster] Move To [Target] On [MoveSpeed] With [Agent]", category: "Action", id: "e99099f720c3b4dc3509f5ab57858565")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<PlayerController> Target;
    [SerializeReference] public BlackboardVariable<float> MoveSpeed;
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    protected override Status OnStart()
    {
        Agent.Value.speed = MoveSpeed.Value;
        Agent.Value.GetComponent<NavMeshAgent>();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Agent.Value.SetDestination(GameManager.Instance.MainPlayer.transform.position);
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

