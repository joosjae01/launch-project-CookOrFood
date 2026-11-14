using UnityEngine;
using UnityEngine.InputSystem;

public class NohTestA : MonoBehaviour
{
    [SerializeField] private InputActionReference _testInput;

    private void OnEnable()
    {
        _testInput.action.Enable();
    }

    private void TempPlayBGM(InputAction.CallbackContext ctx)
    {
        TempAudioManager.Instance.RequestBGM(BGMType.Title);
    }
}
