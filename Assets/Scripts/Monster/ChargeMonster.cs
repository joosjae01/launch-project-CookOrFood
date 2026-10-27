using UnityEngine;

public class ChargeMonster : MonsterBase
{
    [SerializeField] private float _attackSpeed; // 돌격 시 이동 속도 증가량
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private PlayerController _player;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer.Contains(other))
        {
            _player.TakeDamage(Data.Damage);
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
