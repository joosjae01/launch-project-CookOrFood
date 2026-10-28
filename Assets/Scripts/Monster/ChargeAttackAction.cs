using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChargeAttack",
    story: "[Monster] [Charge] to [Target] with [Status]",
    category: "Action",
    id: "a5a9cafa51299c8b190107a14a0edcb0")]
public partial class ChargeAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<Vector3> Charge;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<ChargeMonster> StatusValue;
    private Vector3 _destination;
    private float _elapsedTime;
    
    
    protected override Status OnStart()
    {
        Target.Value = GameManager.Instance.MainPlayer.transform;
        _destination = Target.Value.position;
        Charge.Value = _destination - Monster.Value.transform.position;
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

