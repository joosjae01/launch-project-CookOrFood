using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Scriptable Objects/WeaponStatEnhance")]
public class WeaponStatEnhance : ScriptableObject
{
    [Header("공격력 변화량")]
    public float AttackValueAmount;

    [Header("공격 속도 변화량")]
    public float AttackSpeedEnhance;

    [Header("치명타 확률 변화량")]
    public float CritRateEnhance;

    [Header("치명타 대미지 변화량")]
    public float CritDamageEnhance;

    [Header("강화 등급")]
    public EnhanceGrade Grade;
}
