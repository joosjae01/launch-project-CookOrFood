using UnityEngine;

public class WeaponData : MonoBehaviour
{
    [Header("무기 이름")]
    [field: SerializeField] public string Name { get; set; }

    [Header("무기 공격력")]
    [field: SerializeField] public float AttackValue { get; set; }

    [Header("무기 공격 속도")]
    [field: SerializeField] public float AttackSpeed { get; set; }

    [Header("치명 확률")]
    [field: SerializeField] public float CritRate { get; set; }

    [Header("치명 배율")]
    [field:SerializeField] public float CritDamage { get; set; }
}
