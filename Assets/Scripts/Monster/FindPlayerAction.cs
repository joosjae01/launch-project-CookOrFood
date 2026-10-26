using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindPlayer", story: "[Monster] LookAt [Player]", category: "Action", id: "943991c03c4a19356ffda721a1e1ae3b")]
public partial class FindPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Monster;
    [SerializeReference] public BlackboardVariable<Transform> Player;

    protected override Status OnStart()
    {
        Player.Value = GameManager.Instance.MainPlayerData.transform;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Monster.Value.transform.LookAt(Player.Value);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

