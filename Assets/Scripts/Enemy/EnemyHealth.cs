using System;
using System.Net.Mime;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health, maxHealth = 3f;

    [SerializeField] private EnemyHealthbar healthBar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthbar>();
    }

    public void TakeDamage(float damageAmount)
    {
        
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            GetComponent<EnemyArcher>().enabled = false;
            GetComponentInChildren<Animator>().SetTrigger("Death");
            Destroy(gameObject, 1);
        }
    }
    
    
}
