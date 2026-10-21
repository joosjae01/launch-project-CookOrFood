using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private Transform _cameraTransform;
    
    private PlayerData _playerData;
    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;

    private void Awake() => CacheComponents();
    
    private void OnEnable()
    {
        _moveAction.action.Enable();
    }

    private void Start()
    {
        BindInputActions();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        SetPlayerView();
    }
    
    private void OnDisable()
    {
        UnbindInputActions();
    }

    private void BindInputActions()
    {
        _moveAction.action.performed += OnMove;
        _moveAction.action.canceled += OnMove;
    }

    private void UnbindInputActions()
    {
        _moveAction.action.performed -= OnMove;
        _moveAction.action.canceled -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        PlayerRotate(); // 이 식을 아래로 내리면 버튼을 땠을 때 플레이어가 위를 강제로 처다보게 됩니다.
        _moveDirection = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y).normalized;
    }

    private void PlayerMove()
    {
        _rigidbody.linearVelocity = (_moveDirection * _playerData.Speed);
    }

    private void PlayerRotate()
    {
        transform.forward  = _moveDirection;
    }

    private void SetPlayerView()
    {
        _cameraTransform.transform.position = new Vector3(
            _cameraTransform.position.x,
            _cameraTransform.position.y,
            transform.position.z);
    }
    
    private void CacheComponents()
    {
        _playerData = GetComponent<PlayerData>();
        _rigidbody = GetComponent<Rigidbody>();
    }
}
