using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData;
    
    // TODO: 플레이어가 해야되는 기능들
   
    private void ClampHealth() // 최대체력 이상, 0 이하(사망)을 검사
    {
        if (_playerData.CurrentHealth.Value >= _playerData.MaxHealth.Value)
        {
            _playerData.CurrentHealth.Value = _playerData.MaxHealth.Value;
        }
        else if (_playerData.CurrentHealth.Value <= 0)
        {
            _playerData.IsDead.Value = true;
        }
    }
    
    private void 
    // 현재 경험치가 최대 경험치 이상이 되면 레벨업
    // 현재 경험치가 최대 경험치를 넘긴 만큼 다음 레벨 경험치로 이어짐
    // 현재 레벨이 최대 레벨을 넘어가면 최대 레벨로 변환
}
