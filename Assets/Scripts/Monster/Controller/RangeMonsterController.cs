using UnityEngine;

public class RangeMonsterController : MonoBehaviour
{
    [field: Header("몬스터 타입")]
    [field: SerializeField] public MonsterType Type { get; set; }
}
