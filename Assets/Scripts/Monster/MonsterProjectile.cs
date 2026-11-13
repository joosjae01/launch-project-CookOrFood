using System.Collections;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * (_projectileSpeed * Time.deltaTime), Space.World);
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
