using System;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    private Collider _collider;
    
    // ---------- Event Method ----------

    private void Awake() => CacheComponents();

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ExitPortal: 트리거 엔터");
        StageManager.Instance.ExitStage();
        _collider.enabled = false;
    }

    // ---------------------------------

    private void CacheComponents()
    {
        _collider = GetComponent<Collider>();
    }
}
