using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    [SerializeField] int maxAmmo;
    [SerializeField] int maxDistance;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] byte timeReload;
    [SerializeField] TextMeshProUGUI ammoText;
    private int countAmmo;
    private void Awake()
    {
        countAmmo = maxAmmo;
    }

    private void Update()
    {
        Shoot();
        UIAmmo();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && countAmmo > 0)
        {
            countAmmo--;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(transform.position, transform.forward * 100, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, enemyMask))
            {
                Debug.Log($"Hit {hit.collider.gameObject}");
                Destroy(hit.collider.gameObject);
            }
        }

        else if ((Input.GetKeyDown(KeyCode.Mouse0) && countAmmo <= 0) || (Input.GetKeyDown(KeyCode.R)))
        {
            Invoke("Reload", timeReload);
        }
        
    } 

    void Reload()
    {
        countAmmo = maxAmmo;
    }

    void UIAmmo()
    {
        ammoText.text = $"{countAmmo} / {maxAmmo}";
    }
    
}
