using UnityEngine;

[CreateAssetMenu(fileName = "BasicMoveLogic", menuName = "Scriptable Objects/Basic/Move")]
public class BasicMoveLogic : MoveLogicEnhance
{
    public override void Move(ProjectileController projectile, float moveSpeed)
    {
        projectile.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }
}
