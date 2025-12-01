using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.collider.gameObject.name);
        hasHit = true;
        rb.linearVelocity = Vector2.zero;
        
        Destroy(gameObject);

        if (collision.gameObject.TryGetComponent(out EnemyHealth enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
    }
}
