using System.Net.Mime;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health, maxHealth = 3f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
}
