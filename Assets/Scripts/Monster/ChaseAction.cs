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
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> MoveSpeed;
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    protected override Status OnStart()
    {
        Agent.Value.speed = MoveSpeed.Value;
        Agent.Value.GetComponent<NavMeshAgent>();
        Target.Value = GameManager.Instance.MainPlayer.transform;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Debug.Log($"ChaseAction: {Agent.Value.speed}");
        Debug.Log($"ChaseAction: {Agent.Value.angularSpeed}");
        Debug.Log($"ChaseAction: {Agent.Value.acceleration}");
        Agent.Value.SetDestination(Target.Value.transform.position);
        return Status.Success;
    }
    
    protected override void OnEnd()
    {
    }
}

