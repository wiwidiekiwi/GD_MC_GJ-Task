using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowSpawnPosition;
    public float shootingDistance;
    private float timer;
    public float shootInterval;
    public float speed;

    private GameObject player;
    public bool flip;
    public float enemySpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    //if player is in trigger (triggerenter) -> shoot (above or instantiate), else -> don't shoot
    void Update()
    {
        Vector2 direction = player.transform.position - arrowSpawnPosition.transform.position;
        if (direction.magnitude <= shootingDistance)
        {
            
            timer += Time.deltaTime;
            if (timer > shootInterval)
            {
                timer = 0;
                Shoot();
            } 
        }

        Vector2 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(enemySpeed * Time.deltaTime, 0,0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(enemySpeed * Time.deltaTime * -1, 0,0);
        }

        transform.localScale = scale;
    }

    void Shoot()
    {
        GameObject spawnedArrow = Instantiate(arrow, arrowSpawnPosition.position, Quaternion.identity); //Quaternion = rotation
        Rigidbody2D arrowRigidbody = spawnedArrow.GetComponent<Rigidbody2D>();
        Vector2 direction = player.transform.position - arrowSpawnPosition.transform.position;
        arrowRigidbody.linearVelocity = direction.normalized * speed;
    }
    
    
}
