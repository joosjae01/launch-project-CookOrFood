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
        if (_playerData.CurrentHealth.Value > 20.0f)
        {
            _playerData.CurrentHealth.Value -= 20f;    
        }
        else
        {
            _playerData.CurrentHealth.Value = 0.0f;
        }
        Debug.Log(_playerData.CurrentHealth.Value);
    }
}
