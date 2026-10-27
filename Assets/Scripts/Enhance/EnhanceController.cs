using System.Collections.Generic;
using UnityEngine;

public class EnhanceController : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private ProjectileData _projectileData;

    public void AddEnhance(PlayerStatEnhance enhance)
    {
        _playerData.MaxHealth.Value += enhance.HealthAmount;
        _playerData.Speed += enhance.SpeedAmount;
    }

    public void AddEnhance(WeaponStatEnhance enhance)
    {
        _weaponData.AttackValue += enhance.AttackValueAmount;
        _weaponData.AttackSpeed += enhance.AttackSpeedAmount;
        _weaponData.CritRate += enhance.CritRateAmount;
        _weaponData.CritDamage += enhance.CritDamageAmount;
    }

    public void AddEnhance(FireLogicEnhance enhance)
    {
        _projectileData.OnFired.AddListener(enhance.Fire);
    }

    public void AddEnhance(MoveLogicEnhance enhance)
    {
        _projectileData.OnMoved.RemoveAllListeners();
        _projectileData.OnMoved.AddListener(enhance.Move);
    }

    public void AddEnhance(AttackLogicEnhance enhance)
    {
        _projectileData.OnAttacked.AddListener(enhance.Attack);
    }

    public void AddEnhance(BlockLogicEnhance enhance)
    {
        _projectileData.OnBlocked.AddListener(enhance.Block);
    }
}
