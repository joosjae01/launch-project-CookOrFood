using UnityEngine;

public static class LayerMaskExtensions
{
    public static void Add(ref this LayerMask mask, int layer)
    {
        mask |= (1 << layer);
    }

    public static void Remove(ref this LayerMask mask, int layer)
    {
        mask &= ~(1 << layer);
    }

    public static bool Contains(this LayerMask mask, int layer)
    {
        return (0 != (mask & (1 << layer)));
    }

    public static bool Contains(this LayerMask mask, GameObject obj)
    {
        if (obj == null) return false;
        return (0 != (mask & (1 << obj.layer)));
    }

    public static bool Contains(this LayerMask mask, Component component)
    {
        if (component == null) return false;
        return (0 != (mask & (1 << component.gameObject.layer)));
    }
}
