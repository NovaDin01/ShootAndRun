using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int health;
    public static GameObject enemy;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {

    }

    void EnemyHealth()
    {
        if (health > 0)
        {
            Destroy(enemy);
        }
    }
}
