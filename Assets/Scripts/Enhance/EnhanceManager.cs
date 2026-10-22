using System;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceManager : SingletonBehaviour<EnhanceManager>
{
    [Header("현재 적용된 강화 효과")]
    [SerializeField] private List<Enhance> _currentEnhace = new();
    private void Awake() => SetSingleton();

    [SerializeField] private StatEnhanceController _statEnhanceController;
    //TODO: 투사체 강화 컨트롤러 구현 후 연동 필요
    //[SerializeField] private ProjectileEnhanceController _projectileEnhanceController;

    public event Action OnProjectileCreated;
    public event Action OnProjectileStartMoved;
    public event Action OnProjectileHitMonster;
    public event Action OnProjectileHitWall;

    public void AddEnhance(Enhance enhance)
    {
        _currentEnhace.Add(enhance);
    }
}