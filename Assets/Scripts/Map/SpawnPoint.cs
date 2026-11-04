using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.darkRed;
        
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
