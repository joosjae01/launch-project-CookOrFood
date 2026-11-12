using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GeneralSlotBinder : MonoBehaviour
{
    [SerializeField] private List<SlotView> _slotView;
    [SerializeField] private SlotMachine _slotMachine;

    //TODO : 테스트용 입력, 추후 삭제
    [SerializeField] private InputActionReference _testInput;

    private void OnEnable() => BindEvents();
    private void OnDisable() => UnBindEvents();

    private void Test(InputAction.CallbackContext context)
    {
        _slotMachine.TryGeneralSlot();
        Init();
    }

    private void Init()
    {
        //GameManager.Instance.PauseGame();
        for(int i = 0; i < _slotView.Count; i++)
        {
            _slotView[i].enhance = _slotMachine.GeneralSlotMachine[i].Enhance;
            _slotView[i].RefreshName(_slotMachine.GeneralSlotMachine[i].Name);
            _slotView[i].RefreshDesc(_slotMachine.GeneralSlotMachine[i].Desc);
            _slotView[i].RefreshImage(_slotMachine.GeneralSlotMachine[i].Icon);
            _slotView[i].RefreshButton();
        }
    }

    private void BindEvents()
    {
        _testInput.action.Enable();
        _testInput.action.performed += Test;
    }

    private void UnBindEvents()
    {
        _testInput.action.Disable();
        _testInput.action.performed -= Test;
    }
}
