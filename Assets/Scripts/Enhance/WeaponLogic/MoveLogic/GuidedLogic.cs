using UnityEngine;


[CreateAssetMenu(fileName = "GuidedLogicEnhance", menuName = "Scriptable Objects/Enhance/Move/GuidedLogicEnhance")]
public sealed class GuidedLogic : MoveLogicEnhance
{
    public override void Move(ProjectileController projectile, float moveSpeed)
    {
        if (projectile.Target == null) return;
        Vector3 MoveTo = projectile.WeaponData.CurrentTarget.transform.position - projectile.transform.position;
        MoveTo.y = projectile.transform.position.y;
        projectile.transform.Translate(MoveTo * moveSpeed * Time.deltaTime);
    }
}