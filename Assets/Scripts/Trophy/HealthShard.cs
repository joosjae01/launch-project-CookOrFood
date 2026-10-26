using UnityEngine;

public class HealthShard : MonoBehaviour, ICollectable, IPoolable
{
    [SerializeField] private float _healthAmount;
    [SerializeField] private LayerMask _playerLayer;

    public string Name { get; set; }
    public bool CanCollect { get; set; }
    public float DropRate { get; set; }

    public GameObject GameObject { get => gameObject; }

    public ObjectPool Source { get; set; }

    private PlayerData _playerData;

    private void Start()
    {
        _playerData = GameManager.Instance.MainPlayerData;
    }

    private void OnEnable()
    {
        CanCollect = false;
        _playerData.CurrentHealth.AddListener(CheckPlayerHealth);
    }

    private void OnDisable()
    {
        _playerData.CurrentHealth.RemoveListener(CheckPlayerHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CanCollect && _playerLayer.Contains(other))
        {
            Collect();
            ReturnToPool();
        }
    }

    private void CheckPlayerHealth(float health)
    {
        if (health < _playerData.MaxHealth.Value)
        {
            CanCollect = true;
        }
    }

    // TODO : 다음 방으로 넘어가는 이벤트에서, 소환된 체력 조각을 풀로 되돌려야 한다.
    private void CleanShard()
    {
        ReturnToPool();
    }

    public void CheckCanCollect()
    {

    }

    public void Collect()
    {
        if(_playerData.CurrentHealth.Value + _healthAmount > _playerData.MaxHealth.Value)
        {
            _playerData.CurrentHealth.Value = _playerData.MaxHealth.Value;
        }
        else
        {
            _playerData.CurrentHealth.Value += _healthAmount;
        }
    }

    public void ReturnToPool()
    {
        Source.Push(this);
    }
}
