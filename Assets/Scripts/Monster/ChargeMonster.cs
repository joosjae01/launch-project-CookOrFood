using UnityEngine;

public class ChargeMonster : MonsterBase
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private PlayerController _player;
    [field : SerializeField] public float _chargeTime { get; private set; }

    public Rigidbody _rigidbody { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer.Contains(other))
        {
            Debug.Log("Monster 플레이어와 충돌!");
            // _player.TakeDamage(Data.Damage);
        }
        Debug.Log("아잉 충돌!");
    }
    
    public override void Attack(Transform target)
    {
        
    }
    
    private float InforceDamage(float damage) // 1.5배 된 공격력 반환
    {
        damage *= 1.50f;
        return damage;
    }
}
