using UnityEngine;
using UnityEngine.InputSystem;

public class NohTestA : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] InputActionReference _testAAction;

    private void Start()
    {
        _testAAction.action.Enable();
    }

    private void OnEnable()
    {
        _testAAction.action.performed += TestFooA;
    }

    private void TestFooA(InputAction.CallbackContext ctx)
    {
        _playerData.CurrentHealth.Value -= 20f;
        Debug.Log(_playerData.CurrentHealth.Value);
    }
}
