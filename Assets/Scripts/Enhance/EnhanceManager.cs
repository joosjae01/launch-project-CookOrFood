using System;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceManager : SingletonBehaviour<EnhanceManager>
{
    [Header("현재 적용된 강화 효과")]
    [SerializeField] private List<EnhanceBase> _currentEnhace = new();
    private Dictionary<EnhanceType, List<EnhanceBase>> _totalEnhance = new();
    private void Awake() => SetSingleton();

    [SerializeField] private StatEnhanceController _statEnhanceController;
    [SerializeField] private ProjectileEnhanceController _projectileEnhanceController;

    public void AddEnhance(EnhanceBase enhance) => _currentEnhace.Add(enhance);
    public void ResetEnhance() => _currentEnhace.Clear();
}