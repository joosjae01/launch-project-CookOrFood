using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private MonsterData _monsterData;
    
    private NavMeshAgent _agent;

    private void Awake() => CacheComponents();
    
    public void 
    
    private void CacheComponents()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
}
