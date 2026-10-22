using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class StageManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _changeStageAction;
    [SerializeField] private GameObject _playerTransform;
    [SerializeField] private StageBase _tutorialStage;
    [SerializeField] private List<StageBase> _normalStageList;
    [SerializeField] private List<StageBase> _eventStageList;
    
    private int _stageIndex;
    private StageBase _currentStage;

    // ---------- Event Method ----------
    
    private void Awake()
    {
        DeactiveStage();
        
        _stageIndex = 0;
        StartStage(_stageIndex);
    }

    private void OnEnable()
    {
        _changeStageAction.action.Enable();

        _changeStageAction.action.performed += ActionExit;
    }

    // ---------------------------------

    private void DeactiveStage()
    {
        _tutorialStage?.gameObject.SetActive(false);
        
        for (int i = 0; i < _normalStageList.Count; i++)
        {
            _normalStageList[i]?.gameObject.SetActive(false);
        }

        for (int i = 0; i < _eventStageList.Count; i++)
        {
            _eventStageList[i]?.gameObject.SetActive(false);
        }
    }
    
    private void StartStage(int index)
    {
        
        _currentStage = SetStage();
        _currentStage.gameObject.SetActive(true);
        _currentStage.transform.position = new Vector3(0f, 0f, 4f);
        
        _currentStage.ResetStage();
        _currentStage.Enter();

        _playerTransform.transform.position = Vector3.zero;

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
            int index = Random.Range(0, _normalStageList.Count);
            return _normalStageList[index];
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
    
    private void ActionExit(InputAction.CallbackContext context)
    {
        ExitStage();
    }
}
