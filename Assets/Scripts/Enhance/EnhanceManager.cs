using System.Collections.Generic;
using UnityEngine;

public class EnhanceManager : SingletonBehaviour<EnhanceManager>
{
    [SerializeField] private List<EnhanceBase> _currentEnhace = new();
    [SerializeField] private List<EnhanceBase> _totalEnhance = new();
    private void Awake() => SetSingleton();
    private void Start() => Init();

    [SerializeField] private EnhanceController _enhanceController;

    [SerializeField] private List<PlayerStatEnhance> _playerEnhanceList = new();
    [SerializeField] private List<WeaponStatEnhance> _weaponEnhanceList = new();
    [SerializeField] private List<FireLogicEnhance> _fireEnhanceList = new();
    [SerializeField] private List<MoveLogicEnhance> _moveEnhanceList = new();
    [SerializeField] private List<AttackLogicEnhance> _attackEnhanceList = new();
    [SerializeField] private List<BlockLogicEnhance> _blockEnhanceList = new();

    public void ApplyEnhance(EnhanceBase enhance)
    {   
        if (enhance is PlayerStatEnhance) _enhanceController.AddEnhance(enhance as PlayerStatEnhance);
        else if (enhance is WeaponStatEnhance) _enhanceController.AddEnhance(enhance as WeaponStatEnhance);
        else if (enhance is FireLogicEnhance) _enhanceController.AddEnhance(enhance as FireLogicEnhance);
        else if (enhance is MoveLogicEnhance) _enhanceController.AddEnhance(enhance as MoveLogicEnhance);
        else if (enhance is AttackLogicEnhance) _enhanceController.AddEnhance(enhance as AttackLogicEnhance);
        else if (enhance is BlockLogicEnhance) _enhanceController.AddEnhance(enhance as BlockLogicEnhance);

        _currentEnhace.Add(enhance);
    }
    public void ResetEnhance() => _currentEnhace.Clear();

    private void Init()
    {
        InitEnhance<PlayerStatEnhance>(_playerEnhanceList);
        InitEnhance<WeaponStatEnhance>(_weaponEnhanceList);
        InitEnhance<FireLogicEnhance>(_fireEnhanceList);
        InitEnhance<MoveLogicEnhance>(_moveEnhanceList);
        InitEnhance<AttackLogicEnhance>(_attackEnhanceList);
        InitEnhance<BlockLogicEnhance>(_blockEnhanceList);
    }

    private void InitEnhance<T>(List<T> enhanceList) where T : EnhanceBase
    {
        foreach (T enhance in enhanceList)
        {
            _totalEnhance.Add(enhance);
        }
    }
}