using UnityEngine;

public class ChargeMonster : MonsterBase
{
    // TODO : 돌진형 몬스터의 공격 로직을 구현하도록 한다.
    [SerializeField] private float _attackSpeed; // 돌격 시 이동 속도 증가량

    private bool _isTargetInDistance;
    
    public override void Attack(Transform target) // 돌진 공격
    {
        Transform targetTransform = target;
        if (targetTransform != null)
        {
            transform.LookAt(targetTransform);
        }
    }
    
    // 2. 준비 시간 동안 제자리에서 힘을 모아 플레이어를 주시한다. 연출 포함
    // 3. 준비 시간이 끝나면 플레이어에게 달려든다.
    // 4. 달려드는 공격 중에는 공격력이 1.5배이다.
    // 5. 플레이어와 충돌했을 때 현재 공격력 만큼 피해를 준다
    private float InforceDamage(float damage) // 1.5배 된 공격력 반환
    {
        damage *= 1.50f;
        return damage;
    }
}
