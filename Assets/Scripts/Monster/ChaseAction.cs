using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[Monster] Chase [Target] On [MoveSpeed] With [Agent]", category: "Action", id: "e99099f720c3b4dc3509f5ab57858565")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<MonsterController> MoveSpeed;
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    protected override Status OnStart()
    {
        Agent.Value.speed = MoveSpeed.Value.Data.Speed;
        Agent.Value.GetComponent<NavMeshAgent>();
        Target.Value = GameManager.Instance.MainPlayer.transform;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Agent.Value.SetDestination(Target.Value.transform.position);
        return Status.Success;
    }
    
    protected override void OnEnd()
    {
        // Agent.Value.speed = 0.0f;
    }
}

