using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatEnhance", menuName = "Scriptable Objects/PlayerStatEnhance")]
public class PlayerStatEnhance : Enhance
{
    [Header("체력 변화량")]
    public float HealthAmount;

    [Header("이동 속도 변화량")]
    public float SpeedAmount;
}
