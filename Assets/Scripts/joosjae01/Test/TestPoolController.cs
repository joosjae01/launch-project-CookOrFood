using UnityEngine;
using UnityEngine.InputSystem;

public class TestPoolController : MonoBehaviour
{
    [SerializeField] private InputActionReference _spaceInput;

    private void Awake()
    {
        _spaceInput.action.Enable();
        _spaceInput.action.performed += OnPressed;
    }

    private void OnPressed(InputAction.CallbackContext context)
    {
        PoolManager.Instance.Pool["sample"].Take();
    }
}
