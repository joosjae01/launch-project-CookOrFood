using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChargeAttack", story: "[ChargeMonster] [Attack] [Target]", category: "Action", id: "3af70d796f6fae5c38869d6dd555edcc")]
public partial class ChargeAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> ChargeMonster;
    [SerializeReference] public BlackboardVariable<ChargeMonster> Attack;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    protected override Status OnStart()
    {
        Attack.Value.Attack(Target.Value);
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

