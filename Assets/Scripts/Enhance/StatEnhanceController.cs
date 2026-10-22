using System.Collections.Generic;
using UnityEngine;

public class StatEnhanceController : MonoBehaviour
{
    [Header("플레이어 스탯 변동")]
    [SerializeField] private List<PlayerStatEnhance> _playerEnhanceList = new();

    [Header("무기 스탯 변동")]
    [SerializeField] private List<WeaponStatEnhance> _weaponEnhanceList = new();

    private PlayerData _playerData;
    private WeaponData _weaponData;

    //TODO: 플레이어 데이터 변경 후 적용 필요
    //private PlayerContext _playerContext;
    private WeaponContext _weaponContext;

    public void Init()
    {
        //TODO: 플레이어 데이터 가져오는 로직 구현 필요
        //TODO: 무기 데이터 가져오는 로직 구현 필요
    }

    public void AddPlayerEnhance(int index)
    {
        //TODO: 플레이어 데이터 변경 후 적용 필요
    }

    public void AddWeaponEnhance(int index)
    {
        _weaponContext.AttackValue = _weaponEnhanceList[index].AttackValueAmount;
        _weaponContext.AttackSpeed = _weaponEnhanceList[index].AttackSpeedAmount;
        _weaponContext.CritRate = _weaponEnhanceList[index].CritRateAmount;
        _weaponContext.CritDamage = _weaponEnhanceList[index].CritDamageAmount;

        _weaponData.IncreaseData(_weaponContext);
        EnhanceManager.Instance.AddEnhance(_weaponEnhanceList[index]);
    }
}
