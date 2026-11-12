using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private int _size;
    public List<Slot> GeneralSlotMachine = new();
    public Slot AngelSlotMachine = new();
    public Slot DevilSlotMachine = new();

    private EnhanceGrade _slotGrade;

    private void Awake() => Init();

    private void ChangeGrade()
    {

    }

    public bool TryGeneralSlot()
    {
        EnhanceBase temp;
        foreach(Slot slot in GeneralSlotMachine)
        {
            temp = EnhanceManager.Instance.GetRandom();
            if(temp == null) return false;
            
            slot.SetSlot(temp);
        }

        return true;
    }

    public bool TryAngelSlot()
    {
        EnhanceBase temp;

        temp = EnhanceManager.Instance.GetRandom();
        
        if (temp == null) return false;
        
        AngelSlotMachine.SetSlot(temp);
        return true;
    }

    public bool TryDevilSlot()
    {
        EnhanceBase temp;

        temp = EnhanceManager.Instance.GetRandom();

        if (temp == null) return false;

        DevilSlotMachine.SetSlot(temp);
        return true;
    }

    private void Init()
    {
        for(int i = 0; i < _size; i++)
        {
            Slot slot = new();
            GeneralSlotMachine.Add(slot);
        }
    }
}
