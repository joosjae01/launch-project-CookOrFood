using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field : SerializeField] public const float MAX_EXP = 100f; // 레벨 업 하기 위한 최대 경험치
    [field : SerializeField] public const int MAX_LEVEL = 20; // 최대 레벨
    [field : SerializeField] public float Speed  { get; private set; } // 이동 속도
    [field : SerializeField] public string Name { get; private set; } // 캐릭터 이름
    
    public ObservableProperty<float> CurrentExp; // 현재 경험치
    public ObservableProperty<float> CurrentLevel; // 현재 레벨
    public ObservableProperty<float> MaxHealth; // 최대 체력
    public ObservableProperty<float> CurrentHealth; // 현재 체력
    public ObservableProperty<bool> IsDead; // 사망 여부
}
