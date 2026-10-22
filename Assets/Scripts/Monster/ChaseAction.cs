using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[Monster] to [Target]", category: "Action/Navigation", id: "e99099f720c3b4dc3509f5ab57858565")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    
    private NavMeshAgent _agent;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        
        _agent.SetDestination(Target.Value.transform.position);
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }

    private void Awake() => CacheComponents();

    private void CacheComponents()
    {
        _agent = Monster.Value.GetComponent<NavMeshAgent>();
        Target.Value = GameObject.FindGameObjectWithTag("Player");
    }
}

