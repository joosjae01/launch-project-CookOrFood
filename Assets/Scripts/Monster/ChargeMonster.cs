using UnityEngine;

public class ChargeMonster : MonsterBase
{
    // TODO : 돌진형 몬스터의 공격 로직을 구현하도록 한다.
    [SerializeField] private float _attackSpeed; // 돌격 시 이동 속도 증가량

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        
        Attack(collision.transform);
    }
    
    public override void Attack(Transform target)
    {
        if (target != null && target.GetComponent<IDamageable>() != null)
        {
            target.GetComponent<IDamageable>().TakeDamage(Data.Damage);
        }
    }
    
    private float InforceDamage(float damage) // 1.5배 된 공격력 반환
    {
        damage *= 1.50f;
        return damage;
    }
}
