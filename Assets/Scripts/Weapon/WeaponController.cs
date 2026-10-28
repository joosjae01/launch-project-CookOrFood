using System.Collections;
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
            _weaponData.OnFired?.Invoke(_muzzlePoint);
        }
    }

    private void CacheComponenet()
    {
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
