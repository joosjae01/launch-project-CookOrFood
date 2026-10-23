using System;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    // ---------- Event Method ----------

    private void OnTriggerEnter(Collider other)
    {
        StageManager.Instance.ExitStage();
    }

    // ---------------------------------
    
}
