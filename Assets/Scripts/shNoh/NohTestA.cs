using UnityEngine;
using UnityEngine.InputSystem;

public class NohTestA : MonoBehaviour
{
    [SerializeField] private InputActionReference _testInput;

    private void OnEnable()
    {
        _testInput.action.Enable();
        _testInput.action.performed += TempAudioManager.Instance.PlaySFX;
    }
}
