using UnityEngine;
using UnityEngine.AI;

public class ChargeMonster : MonsterBase
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
    
    private float InforceDamage(float damage) // 1.5배 된 공격력 반환
    {
        damage *= 1.50f;
        return damage;
    }

    public void Dash()
    {
        _rigidbody.AddForce(Vector3.forward * 10.0f, ForceMode.Impulse);
    }

    public void StopDash()
    {
        _rigidbody.linearVelocity = Vector3.zero;
    }
}
