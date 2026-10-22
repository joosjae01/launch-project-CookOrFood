using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class StageManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _changeStageAction;
    [SerializeField] private GameObject _playerTransform;
    [SerializeField] private GameObject _tutorialStage;
    [SerializeField] private List<GameObject> _normalStageList;
    [SerializeField] private List<GameObject> _eventStageList;
    
    private int _stageIndex;
    private StageBase _currentStage;
    private GameObject _stagePrefab;
    private Vector3 _mapPosition;

    // ---------- Event Method ----------
    
    private void Awake()
    {
        DeactiveStage();
        
        _stageIndex = 0;
        StartStage();
    }

    private void OnEnable()
    {
        _changeStageAction.action.Enable();

        _changeStageAction.action.performed += ActionExit;
    }

    // ---------------------------------

    private void DeactiveStage()
    {
        _tutorialStage?.SetActive(false);
        
        for (int i = 0; i < _normalStageList.Count; i++)
        {
            _normalStageList[i]?.SetActive(false);
        }

        for (int i = 0; i < _eventStageList.Count; i++)
        {
            _eventStageList[i]?.SetActive(false);
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

        _currentStage.OnExitStage += ExitStage;
        
        _stageIndex++;
    }

    private StageBase SetStage()
    {
        if (_stageIndex == 0)
        {
            _stagePrefab = Instantiate(_tutorialStage, null);
            return _stagePrefab.GetComponent<StageBase>();
        }
        else if (_stageIndex % 3 != 0)
        {
            // TODO 여기서 전투맵 피셔 예이츠 셔플해서 리턴
            int index = Random.Range(0, _normalStageList.Count);
            
            _stagePrefab = Instantiate(_normalStageList[index], null);
            
            return _stagePrefab.GetComponent<StageBase>();
        }
        else if (_stageIndex % 3 == 0)
        {
            int index = Random.Range(0, _eventStageList.Count);
         
            _stagePrefab = Instantiate(_eventStageList[index], null);
            
            return _stagePrefab.GetComponent<StageBase>();
        }

        return null;
    }

    private void ExitStage()
    {
        // TODO 페이드아웃
        
        _currentStage.Exit();
        _currentStage.OnExitStage -= ExitStage;
        
        Destroy(_currentStage.gameObject);
        
        // TODO 페이드인
        
        StartStage();
    }
    
    private void ActionExit(InputAction.CallbackContext context)
    {
        ExitStage();
    }
}
