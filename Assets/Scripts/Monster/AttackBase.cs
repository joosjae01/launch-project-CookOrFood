using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    [SerializeField] private Transform _targetPlayer;

    public abstract void StartAttack();
}
