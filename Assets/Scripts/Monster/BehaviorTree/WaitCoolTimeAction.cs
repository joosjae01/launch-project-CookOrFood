using System;
using System.Collections;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WaitCoolTime", story: "[Monster] looks at [Player] until [AttackCoolTime]", category: "Action", id: "889b064b5d5c5b0a7b881f55a65d01af")]
public partial class WaitCoolTimeAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Monster;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    [SerializeReference] public BlackboardVariable<float> AttackCoolTime;
    
    private float elapsedTime;
    protected override Status OnStart()
    {
        elapsedTime = 0;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Monster.Value.LookAt(Player.Value);
        
        elapsedTime += Time.deltaTime;

        if (elapsedTime < AttackCoolTime)
        {
            return Status.Running;
        }
        else
        {
            return Status.Success;
        }
    }
}

