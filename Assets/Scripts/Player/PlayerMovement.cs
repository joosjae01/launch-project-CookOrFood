using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    
    private PlayerData _playerData;
    private Vector3 _moveDirection;

    private void Awake() => CacheComponents();
    
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
        // PlayerRotate();
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
        Debug.Log($"{_moveDirection.x}, {_moveDirection.z}");
    }

    private void PlayerMove()
    {
        transform.Translate(GetMoveDirection() * (Time.deltaTime * _playerData.Speed));
    }

    private void PlayerRotate()
    {
        
    }
    
    private Vector3 GetMoveDirection()
    {
        Vector3 moveDirection = new Vector3(
            _moveDirection.x,
            _moveDirection.y,
            _moveDirection.z).normalized;
        
        return moveDirection;
    }

    private void OnMoveStop(InputAction.CallbackContext ctx)
    {
        _moveDirection.x = 0;
        _moveDirection.z = 0;
    }
    
    private void CacheComponents()
    {
        _playerData = GetComponent<PlayerData>();
    }
}
