using System.Collections.Generic;
using UnityEngine;

public class EnhanceManager : SingletonBehaviour<EnhanceManager>
{
    [SerializeField] private List<EnhanceBase> _currentEnhace = new();
    [SerializeField] private List<EnhanceBase> _totalEnhance = new();
    [SerializeField] private EnhanceController _enhanceController;

    private void Awake() => SetSingleton();
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

    public EnhanceBase GetRandom()
    {
        int select = Random.Range(0, _totalEnhance.Count);
        return _totalEnhance[select];
    }

    public void ResetEnhance() => _currentEnhace.Clear();
}