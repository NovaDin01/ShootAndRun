using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDirection;
    [SerializeField] float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void move()
    {
        
    }

}
