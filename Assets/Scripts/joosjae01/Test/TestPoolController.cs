using UnityEngine;
using UnityEngine.InputSystem;

public class TestPoolController : MonoBehaviour
{
    [SerializeField] private InputActionReference _spaceInput;
    [SerializeField] private PlayerData _playerData;

    private void Awake()
    {
        _spaceInput.action.Enable();
        _spaceInput.action.performed += OnPressed;
    }

    private void OnPressed(InputAction.CallbackContext context)
    {
        IPoolable poolable = PoolManager.Instance.Pool[PoolableType.HealthShard].Take();

        if (poolable == null) return;

        poolable.GameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
        HealthShard healthShard = poolable.GameObject.GetComponent<HealthShard>();
    }
}
