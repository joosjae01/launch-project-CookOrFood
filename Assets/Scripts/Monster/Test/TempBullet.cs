using System;
using System.Collections;
using UnityEngine;

public class TempBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * _bulletSpeed * Time.deltaTime,Space.World);
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
