using UnityEngine;
using UnityEngine.InputSystem;

public class TestPoolController : MonoBehaviour
{
    [SerializeField] private InputActionReference _spaceInput;
    [SerializeField] private ObjectPool _testPool;

    private void Awake()
    {
        _spaceInput.action.Enable();
        _spaceInput.action.performed += OnPressed;
    }

    private void OnPressed(InputAction.CallbackContext context)
    {
        _testPool.Take();
    }
}
