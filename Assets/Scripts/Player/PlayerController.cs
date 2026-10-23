using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private Action _playerDataChange;
    
    // TODO: 플레이어가 해야되는 기능들

    //private void OnEnable() => InitData();
    
    private void Start()
    {
        BindDataChange();
        Debug.Log($"컨트롤러: 현재 체력 {_playerData.CurrentHealth.Value} / {_playerData.MaxHealth.Value}");
        Debug.Log($"컨트롤러: 현재 경험치 {_playerData.CurrentExp.Value} / {_playerData.MAX_EXP}");
        Debug.Log($"컨트롤러: 현재 레벨 {_playerData.CurrentLevel.Value} / {_playerData.MAX_LEVEL}");
        Debug.Log($"컨트롤러: 사망 여부 {_playerData.IsDead.Value}");
    }

    private void OnDisable()
    {
        UnBindDataChange();
    }
    
    private void BindDataChange()
    {
        _playerDataChange += ClampHealth;
        _playerDataChange += LevelUp;
        _playerDataChange += ClampLevel;
    }

    private void UnBindDataChange()
    {
        _playerDataChange -= ClampHealth;
        _playerDataChange -= LevelUp;
        _playerDataChange -= ClampLevel;
    }

    /*private void InitData()
    {
        _playerData = new PlayerData();
    }*/
    
    private void ClampHealth() // 최대체력 이상, 0 이하(사망)을 검사
    {
        // 최대 체력 이상 검사
        if (_playerData.CurrentHealth.Value >= _playerData.MaxHealth.Value)
        {
            _playerData.CurrentHealth.Value = _playerData.MaxHealth.Value;
        }
        // 사망 검사
        else if (_playerData.CurrentHealth.Value <= 0)
        {
            _playerData.IsDead.Value = true;
        }
    }

    private void LevelUp()
    {
        float remainExp;
        
        if (_playerData.CurrentExp.Value >= _playerData.MAX_EXP) // 레벨업 과 잔류 경험치 처리
        {
            remainExp = (_playerData.CurrentExp.Value -  _playerData.MAX_EXP);
            _playerData.CurrentLevel.Value++;
            _playerData.CurrentExp.Value = remainExp;
        }
    }
    
    private void ClampLevel() // 최대 레벨 검사
    {
        if (_playerData.CurrentLevel.Value >= _playerData.MAX_LEVEL)
        {
            _playerData.CurrentLevel.Value = _playerData.MAX_LEVEL;
        }
    }
}
