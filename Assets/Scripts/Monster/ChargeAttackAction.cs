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
    private Vector3 _target;
    private float _agentSpeed;
    private float _agentAngularSpeed;
    private float _agentAcceleration;
    private float _elapsedTime;

    protected override Status OnStart()
    {
        Player.Value = GameManager.Instance.MainPlayer.transform;
        _target = Player.Value.position;
        _agentSpeed = Monster.Value.speed;
        _agentAngularSpeed = Monster.Value.angularSpeed;
        _agentAcceleration = Monster.Value.acceleration;
        Debug.Log(Monster.Value.angularSpeed);
        Debug.Log(Monster.Value.acceleration);
        Debug.Log(Monster.Value.speed);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        _elapsedTime += Time.deltaTime;
        Monster.Value.speed = 15.0f;
        Monster.Value.acceleration = 15.0f;
        Monster.Value.angularSpeed = 0.0f;
        if (_elapsedTime >= 1.0f)
        {
        return Status.Success;
        }
        Monster.Value.SetDestination(_target);
        return Status.Running;
    }

    protected override void OnEnd()
    {
        Monster.Value.speed = _agentSpeed;
        Monster.Value.acceleration = _agentAcceleration;
        Monster.Value.angularSpeed = _agentAngularSpeed;
        _elapsedTime = 0.0f;
    }
}

