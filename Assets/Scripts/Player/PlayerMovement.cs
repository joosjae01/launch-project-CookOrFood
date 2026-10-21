using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    
    private PlayerData _playerData;
    private Vector3 _moveDirection;

    private void OnEnable()
    {
        _moveAction.action.Enable();
    }

    private void Start()
    {
        BindInputActions();
    }

    private void Update()
    {
        PlayerMove();
    }
    private void OnDisable()
    {
        UnbindInputActions();
    }

    private void BindInputActions()
    {
        _moveAction.action.performed += OnMove;
        _moveAction.action.canceled += OnMoveStop;
    }

    private void UnbindInputActions()
    {
        _moveAction.action.performed -= OnMove;
        _moveAction.action.canceled -= OnMoveStop;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        _moveDirection.x = ctx.ReadValue<Vector2>().x;
        _moveDirection.z = ctx.ReadValue<Vector2>().y;
    }

    private void PlayerMove()
    {
        transform.Translate( new Vector3(
            _moveDirection.x,
            _moveDirection.y,
            _moveDirection.z) *  Time.deltaTime * _playerData.Speed);
    }

    private void OnMoveStop(InputAction.CallbackContext ctx)
    {
        _moveDirection.x = 0;
        _moveDirection.z = 0;
    }
}
