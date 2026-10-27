using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChargeAttack", story: "[Monster] [charge] to [Player]", category: "Action", id: "8a8a07a6025763598b4169dcdb4eb8ae")]
public partial class ChargeAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Monster;
    [SerializeReference] public BlackboardVariable<Vector3> Charge;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    private float agentSpeed;
    private float agentAngularSpeed;
    private float agentAcceleration;
    private float elapsedTime;

    protected override Status OnStart()
    {
        agentSpeed = Monster.Value.speed;
        agentAngularSpeed = Monster.Value.acceleration;
        Debug.Log(Monster.Value.angularSpeed);
        Debug.Log(Monster.Value.acceleration);
        Debug.Log(Monster.Value.speed);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        elapsedTime += Time.deltaTime;
        Monster.Value.speed = 6f;
        Monster.Value.acceleration = 15f;
        if (elapsedTime >= 1.0f)
        {
        return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
        Monster.Value.speed =  agentSpeed;
        Monster.Value.acceleration = agentAcceleration;
    }
}

