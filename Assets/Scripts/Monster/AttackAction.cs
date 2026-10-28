using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.Rendering;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "[Monster] dash to [Player] and set [Agent]", category: "Action", id: "534481af103a9753b1a4b1dc643b30b2")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<Rigidbody> Monster;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    private float _elapsedSeconds;
    private float _originSpeed;
    private float _originAngularSpeed;
    private float _originAcceleration;
    private Vector3 _originVelocity;
    private Vector3 _direction;

    protected override Status OnStart()
    {
        Player.Value.position = GameManager.Instance.MainPlayer.transform.position;
    _originSpeed = Agent.Value.speed;
    _originAngularSpeed = Agent.Value.angularSpeed;
    _originAcceleration = Agent.Value.acceleration;
    _originVelocity = Agent.Value.velocity;
    _direction =  Player.Value.position - Agent.Value.transform.position;
    
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Monster.Value.AddForce(_direction * 5, ForceMode.Impulse);
        _elapsedSeconds += Time.deltaTime;
        if (_elapsedSeconds > 2.0f)
        {
            Agent.Value.speed = 0.0f;
            Agent.Value.angularSpeed  = 0.0f;
            Agent.Value.acceleration = 0.0f;
            
            
            Debug.Log(Agent.Value.velocity);
            Agent.Value.velocity = _originVelocity;
            Agent.Value.angularSpeed  = _originAngularSpeed;
            Agent.Value.acceleration = _originAcceleration;
            
            Monster.Value.linearVelocity = Vector3.zero;
            Monster.Value.angularVelocity = Vector3.zero;
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
        Agent.Value.velocity = _originVelocity;
        Agent.Value.angularSpeed  = _originAngularSpeed;
        Agent.Value.acceleration = _originAcceleration;
        
    }
}

