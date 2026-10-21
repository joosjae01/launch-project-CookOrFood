using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field : SerializeField] public const float MAX_EXP = 100f; // 레벨 업 하기 위한 최대 경험치
    [field : SerializeField] public const float MAX_LEVEL = 20f; // 최대 레벨
    [field : SerializeField] public float CurrentExp { get; private set; } // 현재 경험치
    [field : SerializeField] public float CurrentLevel { get; private set; } // 현재 레벨
    [field : SerializeField] public float MaxHealth { get; private set; } // 최대 체력
    [field : SerializeField] public float CurrentHealth { get; private set; } // 현재 체력
    [field : SerializeField] public float Speed  { get; private set; } // 이동 속도
    [field : SerializeField] public string Name { get; private set; } // 캐릭터 이름
    [field : SerializeField] public bool IsDead { get; private set; } // 사망 여부
}
