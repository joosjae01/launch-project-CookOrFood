using Unity.Behavior;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private AttackBase _attackType;
    [SerializeField] private Animator _animator;

    private BehaviorGraphAgent _behaviorAgent;

    private void Awake() => CacheComponents();

    private void Start() => Init();
    
    private void CacheComponents()
    {
        if (_attackType == null) _attackType = GetComponent<AttackBase>();
        _behaviorAgent = GetComponent<BehaviorGraphAgent>();
    }

    private void Init()
    {
        _behaviorAgent.SetVariableValue("attackType", _attackType);
    }
    
    
}
