using System;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    
    private BoxCollider _collider;
    
    // ---------- Event Method ----------

    private void Awake() => CacheComponents();

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskExtensions.Contains(_layerMask.value, other.gameObject.layer))
        {
            StageManager.Instance.ExitStage();
        }
    }

    // ---------------------------------

    private void CacheComponents()
    {
        _collider = GetComponent<BoxCollider>();
    }
}
