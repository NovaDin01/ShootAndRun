using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int timeToLifeBullet;
    [SerializeField] float speedBullet;
    [SerializeField] Rigidbody _rb;
    float lifeBullet;
    

    void Start()
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
            lifeBullet = 0;
            DestroyBullet();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("shoot");
            Enemy.health -= 35;
            if(Enemy.health <= 0)
            {
                Destroy(Enemy.enemy);
            }
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
