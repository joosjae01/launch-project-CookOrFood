using System;
using UnityEngine;

public class Devil : MonoBehaviour, IInteractable
{
    [SerializeField] private LayerMask _playerLayer; 
    
    public GameObject GameObject { get; }

    public event Action OnClear;
    
    // ---------- Event Method ----------
    
    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer.Contains(other))
        {
            StartEvent();
        }
    }
 
    // TODO 추후 특성 고르는 기능이 생기면 없어질 함수
    private void OnTriggerExit(Collider other)
    {
        if (_playerLayer.Contains(other))
        {
            EndEvent();
        }
    }

    // ----------------------------------
    
    public void StartEvent()
    {
        // TODO 특성 돌리기
        // TODO 플레이어 인풋(조이스틱) 비활성화
    }

    public void EndEvent()
    { 
        OnClear?.Invoke();
    }
}
