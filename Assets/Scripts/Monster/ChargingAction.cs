using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "Charging",
    story: "[Monster] Charging to [Player] For [Seconds] and set [Agent] Speed",
    category: "Action",
    id: "aa203333ab5c5c937db5c7062b89301c")]
public partial class ChargingAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<ChargeMonster> Seconds;
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    private float _elapsedSeconds;

    protected override Status OnStart()
    {
        Player.Value = GameManager.Instance.MainPlayer.gameObject;
        Agent.Value.speed = 1.0f;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Monster.Value.transform.LookAt(Player.Value.transform);
        _elapsedSeconds += Time.deltaTime;
        if (_elapsedSeconds > Seconds.Value._chargeTime)
        {
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
        Agent.Value.speed = Seconds.Value.Data.Speed;
        _elapsedSeconds = 0.0f;
    }
}

