using System;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    
    private BoxCollider _collider;
    
    // ---------- Event Method ----------

    private void Awake() => CacheComponents();

    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer.Contains(other))
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
