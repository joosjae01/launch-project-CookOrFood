using UnityEngine;


[CreateAssetMenu(fileName = "GuidedLogicEnhance", menuName = "Scriptable Objects/Enhance/Move/GuidedLogicEnhance")]
public sealed class GuidedLogic : MoveLogicEnhance
{
    public override void Move(ProjectileController projectile, float moveSpeed)
    {
        Vector3 MoveTo = projectile.TargetMonster.transform.position - projectile.transform.position;
        projectile.transform.Translate(MoveTo * moveSpeed * Time.deltaTime);
    }
}
