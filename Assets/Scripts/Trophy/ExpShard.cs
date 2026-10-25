using UnityEditor.Purchasing;
using UnityEngine;

public class ExpShard : MonoBehaviour, ICollectable, IPoolable
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _expAmount;
    [SerializeField] private float _moveSpeed;
    [field : SerializeField] public string Name {  get; set; }
    [field: SerializeField] public bool CanCollect { get; set; }
    [field: SerializeField] public float DropRate {  get; set; }

    public GameObject GameObject {get => gameObject;}

    public ObjectPool Source { get; set; }

    [SerializeField] private PlayerData _targetData;
    private Vector3 _moveTo;

    private void OnEnable()
    {
        //TODO : 나중에 GameManager에서 PlayerData의 참조를 받아, Heating 시켜두도록
        CanCollect = false;
    }

    public void Update()
    {
        if (CanCollect)
        {
            MoveToPlayer();
        }
    }

    private void OnDisable()
    {
        CanCollect = false;
    }

    public void CheckCanCollect()
    {
        //TODO : 스테이지 클리어 되었을 시 획득 가능하도록 해당 이벤트에 구독 처리
        CanCollect = true;
    }

    public void MoveToPlayer()
    {
        _moveTo = _targetData.transform.position - transform.position;
        transform.Translate(_moveTo * _moveSpeed * Time.deltaTime);
    }

    public void Collect()
    {
        if (_targetData == null) return;

        _targetData.CurrentExp.Value += _expAmount;
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        Source.Push(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CanCollect && _playerLayer.Contains(other))
        {
            Debug.Log("경험치 조각 획득");
            Collect();
        }
    }

    //TODO : GameManager 도입 후 삭제
    public void SetPlayerData(PlayerData playerData)
    {
        _targetData = playerData;
    }
}
