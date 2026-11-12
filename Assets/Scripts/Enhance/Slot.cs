using UnityEngine;
using UnityEngine.UI;

public class Slot
{
    public EnhanceBase Enhance { get; private set; }
    public Sprite Icon { get; private set; }
    public string Name { get; private set; }
    public string Desc { get; private set; }
    

    public void SetSlot(EnhanceBase enhance)
    {
        Enhance = enhance;
        Icon = enhance.EnhanceImage;
        Name = enhance.Name;
        Desc = enhance.Desc;
    }
}
