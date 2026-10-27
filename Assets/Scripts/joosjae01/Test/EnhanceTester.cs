using UnityEngine;
using UnityEngine.InputSystem;

public class EnhanceTester : MonoBehaviour
{
    [SerializeField] private EnhanceController _enhanceController;
    [SerializeField] private InputActionReference _testInput;

    private void Awake()
    {
        _testInput.action.Enable();
        _testInput.action.performed += OnPressed;
    }

    private void OnPressed(InputAction.CallbackContext context)
    {

    }
}
