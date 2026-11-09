using System.Collections.Generic;
using UnityEngine;

public class MonsterScanner : MonoBehaviour
{
    //TODO : 테스트 환경을 위해 직렬화 함, 추후 제거할 것
    [SerializeField] private MonsterBase _target;
    [SerializeField] private List<MonsterBase> _currentMonster = new();
    private float _minDist;

    private void OnEnable() => BindEnterAction();
    private void Update() => SetTarget();

    private void BindEnterAction() => StageManager.Instance.OnEntered += GetCurrentMonster;

    private void GetCurrentMonster()
    {
        _currentMonster.Clear();
        _currentMonster = StageManager.Instance.CurrentStage.RemainMonsterList;
    }

    private void SetTarget()
    {
        if (!_currentMonster.Contains(_target)) _target = null;

        if (_target == null) _minDist = int.MaxValue;
        else _minDist = Vector3.Distance(transform.position, _target.transform.position);

        foreach (MonsterBase monster in _currentMonster)
        {
            float tempDist = Vector3.Distance(transform.position, monster.transform.position);
            if (_minDist > tempDist)
            {
                _minDist = tempDist;
                _target = monster;
            }
        }
    }

    public MonsterBase GetTarget() => _target;
}
