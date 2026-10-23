using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public readonly float MAX_EXP = 100f; // 레벨 업 하기 위한 최대 경험치
    public readonly int MAX_LEVEL = 20; // 최대 레벨
    [SerializeField] private float _maxHealth;
    
    [field : SerializeField] public float Speed  { get; private set; } // 이동 속도
    [field : SerializeField] public string Name { get; private set; } // 캐릭터 이름
    
    public ObservableProperty<float> MaxHealth { get; set; }  // 최대 체력
    public ObservableProperty<float> CurrentHealth { get; set; }  // 현재 체력
    public ObservableProperty<float> CurrentExp { get; set; } // 현재 경험치
    public ObservableProperty<int> CurrentLevel { get; set; }  // 현재 레벨
    public ObservableProperty<bool> IsDead { get; set; }  // 사망 여부

    private void Awake() => InitData();
    
    private void InitData()
    {
        MaxHealth.Value = _maxHealth;
        CurrentHealth.Value = _maxHealth;
    }
}
