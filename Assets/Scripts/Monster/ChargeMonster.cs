using UnityEngine;

public class ChargeMonster : MonsterBase
{
    // TODO : 돌진형 몬스터의 공격 로직을 구현하도록 한다.
    [SerializeField] private float _attackSpeed; // 돌격 시 이동 속도 증가량

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
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
