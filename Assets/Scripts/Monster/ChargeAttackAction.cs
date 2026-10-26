using System;
using System.Collections;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChargeAttack", story: "[Monster] Attack [Target]", category: "Action", id: "12b574c5166d80319ee9a0e5fe598490")]
public partial class ChargeAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    private Vector3 _moveTo;
    protected override Status OnStart()
    {
        Target.Value.position = GameManager.Instance.MainPlayer.transform.position;
        _moveTo = Target.Value.position - Monster.Value.transform.position;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Monster.Value.transform.Translate(_moveTo * 60f * Time.deltaTime);
        Debug.Log("Attacked");
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

