using UnityEngine;
using UnityEngine.InputSystem;

public class MonsterKillInvoker : MonoBehaviour
{
    [SerializeField] private InputActionReference _killInput;
    [SerializeField] private MonsterData _monsterData;

    private void OnEnable()
    {
        _killInput.action.Enable();
        _killInput.action.performed += OnKillMonster;
    }

    private void OnDisable()
    {
        _killInput.action.performed -= OnKillMonster;
    }

    private void OnKillMonster(InputAction.CallbackContext ctx)
    {
        _monsterData.OnKilled?.Invoke(_monsterData);
        Debug.Log("kill");
    }
}
