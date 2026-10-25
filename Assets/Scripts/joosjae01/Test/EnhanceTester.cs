using UnityEngine;
using UnityEngine.InputSystem;

public class EnhanceTester : MonoBehaviour
{
    [SerializeField] private StatEnhanceController _statEnhanceController;
    [SerializeField] private InputActionReference _testInput;

    private void Awake()
    {
        _testInput.action.Enable();
        _testInput.action.performed += OnPressed;
    }

    private void OnPressed(InputAction.CallbackContext context)
    {
        _statEnhanceController.AddWeaponEnhance(1);
        _statEnhanceController.AddPlayerEnhance(1);
    }
}
