using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private Transform _muzzlePoint;

    //TODO : 나중에 타겟 몬스터가 있을 때에만 공격하도록 해야 함.
    private Coroutine _fireRoutine;
    private WaitForSeconds _coolDown;

    private void Awake() => CacheComponenet();

    private void OnEnable()
    {
        _moveInput.action.Enable();
        _moveInput.action.performed += OnMove;
        _moveInput.action.canceled += OnStopMove;
    }

    private void OnDisable()
    {
        _moveInput.action.performed -= OnMove;
        _moveInput.action.canceled -= OnStopMove;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        StopFire();
    }

    private void OnStopMove(InputAction.CallbackContext ctx)
    {
        StartFire();
    }


    private void StartFire()
    {
        Debug.Log("발사 시작");
        if (_fireRoutine != null) return;
        _fireRoutine = StartCoroutine(FireRoutine());
    }

    private void StopFire()
    {
        Debug.Log("발사 종료");
        if (_fireRoutine == null) return;
        StopCoroutine(_fireRoutine);
        _fireRoutine = null;
    }

    private IEnumerator FireRoutine()
    {
        while (true)
        {
            yield return _coolDown;
            Debug.Log("발사");
            
            PoolManager.Instance.Pool[PoolableType.Arrow].Take().GameObject.transform.SetPositionAndRotation(_muzzlePoint.position, _muzzlePoint.rotation);
        }
    }

    private void CacheComponenet()
    {
        _coolDown = new WaitForSeconds(1 / _weaponData.AttackSpeed);
    }
}
