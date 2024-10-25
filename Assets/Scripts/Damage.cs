using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float health;
   // [SerializeField] TextMeshProUGUI healthText;
    float currentHealth;

    private void Start()
    {
        currentHealth = health;
    }

    private void Update()
    {
        //healthText.text = currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} получил урон. “екущее здоровье: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} погиб");
    }
}
