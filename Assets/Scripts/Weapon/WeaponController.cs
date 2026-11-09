using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private Transform _muzzlePoint;
    private MonsterScanner _scanner;

    private Coroutine _fireRoutine;
    private WaitForSeconds _coolDown;
    

    private void Awake() => CacheComponenet();
    private void Start() => StartFire();
    private void OnEnable() => BindInput();
    private void OnDisable() => UnBindInput();

    private void OnMove(InputAction.CallbackContext ctx) => StopFire();
    private void OnStopMove(InputAction.CallbackContext ctx) => StartFire();


    private void StartFire()
    {
        if (_fireRoutine != null) return;
        _fireRoutine = StartCoroutine(FireRoutine());
    }

    private void StopFire()
    {
        if (_fireRoutine == null) return;
        StopCoroutine(_fireRoutine);
        _fireRoutine = null;
    }

    private IEnumerator FireRoutine()
    {
        while (true)
        {
            yield return _coolDown;
            _weaponData.CurrentTarget = _scanner.GetTarget();
            if (_weaponData.CurrentTarget != null)
            {
                _muzzlePoint.LookAt(_weaponData.CurrentTarget.transform);
                _weaponData.OnFired?.Invoke(_muzzlePoint, false);
            }
        }
    }

    private void CacheComponenet()
    {
        _scanner = GetComponent<MonsterScanner>();
        _coolDown = new WaitForSeconds(1 / _weaponData.AttackSpeed);
    }

    private void BindInput()
    {
        _moveInput.action.Enable();
        _moveInput.action.performed += OnMove;
        _moveInput.action.canceled += OnStopMove;
    }

    private void UnBindInput()
    {
        _moveInput.action.performed -= OnMove;
        _moveInput.action.canceled -= OnStopMove;
    }
}
