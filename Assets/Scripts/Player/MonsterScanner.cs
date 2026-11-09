using System.Collections.Generic;
using UnityEngine;

public class MonsterScanner : MonoBehaviour
{
    //TODO : 테스트 환경을 위해 직렬화 함, 추후 제거할 것
    [SerializeField] private MonsterBase _target;
    private List<MonsterBase> _currentMonster = new();

    private void Start() => BindEnterAction();
    private void Update() => SetTarget();

    private void BindEnterAction()
    {
        StageManager.Instance.OnEntered += GetCurrentMonster;
    }

    private void GetCurrentMonster()
    {
        _currentMonster.Clear();
        _currentMonster = StageManager.Instance.CurrentStage.RemainMonsterList;
    }

    private void SetTarget()
    {
        if (_currentMonster.Count == 0) _target = null;

        float minDist;

        if (_target == null) minDist = int.MaxValue;
        else minDist = Vector3.Distance(transform.position, _target.transform.position);

        foreach (MonsterBase monster in _currentMonster)
        {
            float tempDist = Vector3.Distance(transform.position, monster.transform.position);
            if (minDist > tempDist)
            {
                minDist = tempDist;
                _target = monster;
            }
        }
    }

    public MonsterBase GetTarget()
    {
        return _target;
    }
}
