using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStatEnhance", menuName = "Scriptable Objects/WeaponStatEnhance")]

public class WeaponStatEnhance : Enhance
{
    [Header("공격력 변화량")]
    public float AttackValueAmount;

    [Header("공격 속도 변화량")]
    public float AttackSpeedAmount;

    [Header("치명타 확률 변화량")]
    public float CritRateAmount;

    [Header("치명타 대미지 변화량")]
    public float CritDamageAmount;
}
