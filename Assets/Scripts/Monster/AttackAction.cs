using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "Attack with [AttackBase]", category: "Action", id: "347610dab81ccd7752d45f0a86cf876e")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<AttackBase> AttackBase;

    protected override Status OnStart()
    {
        AttackBase.Value.StartAttack();
        
        return Status.Success;
    }
}

