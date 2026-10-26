using UnityEngine;
using UnityEngine.InputSystem;

public class TestPoolController : MonoBehaviour
{
    [SerializeField] private InputActionReference _spaceInput;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private MonsterBase _monster;

    private void Awake()
    {
        _spaceInput.action.Enable();
        _spaceInput.action.performed += OnPressed;
    }

    private void OnPressed(InputAction.CallbackContext context)
    {
        _playerData.CurrentHealth.Value -= 10;
        IPoolable poolable = PoolManager.Instance.Pool[PoolableType.Arrow].Take();

        if (poolable == null) return;

        poolable.GameObject.GetComponent<ProjectileController>().TargetMonster = _monster;
        poolable.GameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
