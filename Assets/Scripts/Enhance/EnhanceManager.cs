using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnhanceManager : SingletonBehaviour<EnhanceManager>
{
    [SerializeField] private List<EnhanceBase> _currentEnhace = new();
    [SerializeField] private List<EnhanceBase> _totalEnhance = new();
    [SerializeField] private EnhanceController _enhanceController;
    [SerializeField] private List<EnhanceBase> _basicLogic;

    private void Awake() => SetSingleton();
    private void Start() => Init();
    public void ApplyEnhance(EnhanceBase enhance)
    {
        if (enhance == null) return;
       
        if (!enhance.CanCoExist)
        {
            if (enhance is FireLogicEnhance) RemoveCoExist<FireLogicEnhance>(enhance);
            else if (enhance is MoveLogicEnhance) RemoveCoExist<MoveLogicEnhance>(enhance);
            else if (enhance is AttackLogicEnhance) RemoveCoExist<AttackLogicEnhance>(enhance);
            else if (enhance is BlockLogicEnhance) RemoveCoExist<BlockLogicEnhance>(enhance);
        }

        if (!enhance.CanOverlap)
        {
            _totalEnhance.Remove(enhance);
        }

        _enhanceController.AddEnhance(enhance);
        _currentEnhace.Add(enhance);
    }

    public EnhanceBase GetRandom()
    {
        if (_totalEnhance.Count == 0) return null;
        int select = Random.Range(0, _totalEnhance.Count);
        Debug.Log(_totalEnhance[select]);
        return _totalEnhance[select];
    }

    private void RemoveCoExist<T>(EnhanceBase enhance) where T : EnhanceBase
    {
        T target = null;

        foreach (T logic in _currentEnhace.OfType<T>())
        {
            Debug.Log("?");
            if (!logic.CanCoExist)
            {
                target = logic;
            }
        }

        if(target != null)
        {
            _enhanceController.RemoveEnhance(target);
            _currentEnhace.Remove(target);
        }
    }

    public void ResetEnhance() => _currentEnhace.Clear();

    private void Init()
    {
        foreach(EnhanceBase logic in _basicLogic)
        {
            _enhanceController.AddEnhance(logic);
            _currentEnhace.Add(logic);
        }
    }
}