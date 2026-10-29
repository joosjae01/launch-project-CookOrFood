using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonsterBase
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private PlayerController _player;
    
    [field : SerializeField] public float _chargeTime { get; private set; }

    // private NavMeshAgent _agent;
    private Rigidbody _rigidbody;

    private void Awake() => CacheComponents();
    
    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer.Contains(other))
        {
            Debug.Log("Monster 플레이어와 충돌!");
            // _player.TakeDamage(Data.Damage);
        }
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _monsterAgent = GetComponent<NavMeshAgent>();
    }
    
    public override void Attack(Transform target)
    {
        
    }

    public override void Move(Transform target)
    {
        
    }
}
