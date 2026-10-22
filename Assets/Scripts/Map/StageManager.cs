using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerTransform;
    [SerializeField] private StageBase _tutorialStage;
    [SerializeField] private List<StageBase> _normalStageList;
    [SerializeField] private List<StageBase> _eventStageList;
    
    private int _stageIndex;
    private StageBase _currentStage;

    private void Awake()
    {
        for (int i = 0; i < _normalStageList.Count; i++)
        {
            _normalStageList[i].gameObject.SetActive(false);
        }
        _stageIndex = 0;
        StartStage(_stageIndex);
    }
    
    private void StartStage(int index)
    {
        
        _currentStage = SetStage();
        _currentStage.gameObject.SetActive(true);
        _currentStage.ResetStage();
        _currentStage.Enter();

        _currentStage.OnExitStage += ExitStage;
        
        _stageIndex++;
    }

    private StageBase SetStage()
    {
        if (_stageIndex == 0)
        {
            return _tutorialStage;
        }
        else if (_stageIndex % 3 != 0)
        {
            // TODO 여기서 전투맵 피셔 예이츠 셔플해서 리턴
        }
        else if (_stageIndex % 3 == 0)
        {
            int index = Random.Range(0, _eventStageList.Count);
            
            return _eventStageList[index];
        }

        return null;
    }

    private void ExitStage()
    {
        // TODO 페이드아웃
        _currentStage.Exit();
        _currentStage.OnExitStage -= ExitStage;
        
        _currentStage.gameObject.SetActive(false);
        
        // TODO 페이드인
        StartStage(_stageIndex);
    }
}
