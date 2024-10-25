using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int timeToLifeBullet;
    [SerializeField] float speedBullet;
    [SerializeField] Rigidbody _rb;
    float lifeBullet;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.left * speedBullet;
    }

    void Update()
    {
        if (lifeBullet < timeToLifeBullet)
        {
            lifeBullet += Time.deltaTime;
        }
        else
        {
            DestroyBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if(collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("prop"))
            DestroyBullet();

            Damage damage = collision.gameObject.GetComponent<Damage>();
            if (collision.gameObject.CompareTag("enemy"))
            {
                damage.TakeDamage(1);
            }

        }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
