using System.Collections.Generic;
using UnityEngine;

public class StatEnhanceController : MonoBehaviour
{
    [Header("플레이어 스탯 변동")]
    [SerializeField] private List<PlayerStatEnhance> _playerEnhanceList = new();

    [Header("무기 스탯 변동")]
    [SerializeField] private List<WeaponStatEnhance> _weaponEnhanceList = new();

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private WeaponData _weaponData;

    public void Init()
    {
        //TODO: 플레이어 데이터 가져오는 로직 구현 필요
        //TODO: 무기 데이터 가져오는 로직 구현 필요
    }

    public void AddPlayerEnhance(int index)
    {
        //TODO: 플레이어 데이터 변경 후 적용 필요
        _playerData.MaxHealth.Value += _playerEnhanceList[index].HealthAmount;
        _playerData.Speed += _playerEnhanceList[index].SpeedAmount;

        EnhanceManager.Instance.AddEnhance(_playerEnhanceList[index]);
    }

    public void AddWeaponEnhance(int index)
    {
        _weaponData.AttackValue += _weaponEnhanceList[index].AttackValueAmount;
        _weaponData.AttackSpeed += _weaponEnhanceList[index].AttackSpeedAmount;
        _weaponData.CritRate += _weaponEnhanceList[index].CritRateAmount;
        _weaponData.CritDamage += _weaponEnhanceList[index].CritDamageAmount;

        EnhanceManager.Instance.AddEnhance(_weaponEnhanceList[index]);
    }
}
