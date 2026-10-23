using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerData _playerData;
    
    public GameObject GameObject { get; set; }
    
    private void OnEnable()
    {
        _playerData.CurrentExp.AddListener(LevelUp);
        _playerData.CurrentLevel.AddListener(ClampLevel);
        _playerData.CurrentHealth.AddListener(ClampHealth);
    }

    private void OnDisable()
    {
        _playerData.CurrentExp.RemoveListener(LevelUp);
        _playerData.CurrentLevel.RemoveListener(ClampLevel);
        _playerData.CurrentHealth.RemoveListener(ClampHealth);
    }

    private void ClampHealth(float health) // 최대체력 이상, 0 이하(사망)을 검사
    {
        // 최대 체력 이상 검사
        if (health > _playerData.MaxHealth.Value)
        {
            _playerData.CurrentHealth.Value = _playerData.MaxHealth.Value;
        }
        // 사망 검사
        else if (health <= 0.0f )
        {
            _playerData.IsDead.Value = true;
        }
    }

    private void LevelUp(float currentExp)
    {
        if (currentExp >= _playerData.MAX_EXP) // 레벨업 과 잔류 경험치 처리
        {
            _playerData.CurrentLevel.Value++;
            _playerData.CurrentExp.Value = currentExp - _playerData.MAX_EXP;
        }
    }
    
    private void ClampLevel(int level) // 최대 레벨 검사
    {
        if (level >= _playerData.MAX_LEVEL)
        {
            _playerData.CurrentLevel.Value = _playerData.MAX_LEVEL;
        }
    }

    public void TakeDamage(float damage)
    {
        
    }
}
