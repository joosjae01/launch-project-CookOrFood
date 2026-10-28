using System.Collections.Generic;
using UnityEngine;

public class EnhanceController : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private ProjectileData _projectileData;

    public void AddEnhance(EnhanceBase enhance)
    {
        if (enhance is PlayerStatEnhance) AddEnhance(enhance as PlayerStatEnhance);
        else if (enhance is WeaponStatEnhance) AddEnhance(enhance as WeaponStatEnhance);
        else if (enhance is FireLogicEnhance) AddEnhance(enhance as FireLogicEnhance);
        else if (enhance is MoveLogicEnhance) AddEnhance(enhance as MoveLogicEnhance);
        else if (enhance is AttackLogicEnhance) AddEnhance(enhance as AttackLogicEnhance);
        else if (enhance is BlockLogicEnhance) AddEnhance(enhance as BlockLogicEnhance);
    }

    public void RemoveEnhance(EnhanceBase enhance)
    {
        if (enhance is FireLogicEnhance) RemoveEnhance(enhance as FireLogicEnhance);
        else if (enhance is MoveLogicEnhance) RemoveEnhance(enhance as MoveLogicEnhance);
        else if (enhance is AttackLogicEnhance) RemoveEnhance(enhance as AttackLogicEnhance);
        else if (enhance is BlockLogicEnhance) RemoveEnhance(enhance as BlockLogicEnhance);
    }

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
        _weaponData.OnFired.AddListener(enhance.Fire);
    }

    public void AddEnhance(MoveLogicEnhance enhance)
    {
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

    public void RemoveEnhance(FireLogicEnhance enhance)
    {
        _weaponData.OnFired.RemoveListener(enhance.Fire);
    }

    public void RemoveEnhance(MoveLogicEnhance enhance)
    {
        _projectileData.OnMoved.RemoveListener(enhance.Move);
    }

    public void RemoveEnhance(AttackLogicEnhance enhance)
    {
        _projectileData.OnAttacked.RemoveListener(enhance.Attack);
    }

    public void RemoveEnhance(BlockLogicEnhance enhance)
    {
        _projectileData.OnBlocked.RemoveListener(enhance.Block);
    }
}
