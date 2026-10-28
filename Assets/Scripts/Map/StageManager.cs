using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class StageManager : SingletonBehaviour<StageManager>
{
    [SerializeField] private InputActionReference _changeStageAction;
    [SerializeField] private GameObject _playerTransform;
    [SerializeField] private List<StageBase> _stages;
    
    private StageBase _tutorialStage;
    private StageBase _bossStage;
    private List<StageBase> _combatStageList = new();
    private List<StageBase> _eventStageList = new();
    private int _stageIndex;
    private int _shuffleIndex;
    private StageBase _currentStage;
    private GameObject _stagePrefab;
    private Vector3 _mapPosition;

    // ---------- Event Method ----------
    
    private void Awake()
    { 
        SetSingleton();
        
        InitStages();
        _stageIndex = 0;
        StartStage();
    }

    private void OnEnable()
    {
        // 맵 변경 테스트용 InputSystem
        _changeStageAction.action.Enable();
        _changeStageAction.action.performed += ActionExit;
    }

    // ----------------------------------

    private void InitStages()
    { 
        for (int i = 0; i < _stages.Count; i++)
        {
            _stagePrefab = Instantiate(_stages[i].gameObject, null);
            
            switch (_stages[i].StageType)
            {
                case StageType.Tutorial:
                    _stagePrefab.SetActive(false);
                    _tutorialStage = _stagePrefab.GetComponent<StageBase>();
                    break;
                case StageType.Combat:
                    _stagePrefab.SetActive(false);
                    _combatStageList.Add(_stagePrefab.GetComponent<StageBase>());
                    break;
                case StageType.Event:
                    _eventStageList.Add(_stagePrefab.GetComponent<StageBase>());
                    _stagePrefab.SetActive(false);
                    break;
                case StageType.Boss:
                    _stagePrefab.SetActive(false);
                    _bossStage = _stagePrefab.GetComponent<StageBase>();
                    break;
            }
        }
    }
    
    private void StartStage()
    {
        _currentStage = SetStage();
        _currentStage.gameObject.SetActive(true);
        
        _currentStage.transform.position = Vector3.zero;
        
        _currentStage.ResetStage();
        _currentStage.Enter();
        
        _playerTransform.transform.position = _currentStage.PlayerSpawnPoint.position;
        
        _stageIndex++;
    }

    private StageBase SetStage()
    {
        if (_stageIndex == 0)
        {
            return _tutorialStage;
        }

        if (_stageIndex == 18)
        {
            return _bossStage;
        }
        
        if (_stageIndex % 3 != 0)
        {
            if (_shuffleIndex == 4)
            {
                ShuffleStage();
                _shuffleIndex = 0;
            }
            return _combatStageList[_shuffleIndex++];
        }
        
        if (_stageIndex % 3 == 0)
        {
            //int index = Random.Range(0, _eventStageList.Count);
            
            return _eventStageList[0];
        }

        return null;
    }

    private void ShuffleStage()
    {
        for (int i = _combatStageList.Count; i > 0; i--)
        {
            int index = Random.Range(0, i);
            
            (_combatStageList[i - 1], _combatStageList[index]) =
                (_combatStageList[index], _combatStageList[i - 1]);
        }
    }
    
    // 맵 변경 테스트용 InputSystem 
    private void ActionExit(InputAction.CallbackContext context)
    {
        _currentStage.ClearStage();
    }
    
    public void ExitStage()
    {
        // TODO 페이드아웃
        
        _currentStage.Exit();
        
        _currentStage.gameObject.SetActive(false);
        
        // TODO 페이드인
        
        StartStage();
    }
}
