using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPosition;
    public Transform arrowSpawnPosition;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject spawnedArrow = Instantiate(arrow, arrowSpawnPosition.position, Quaternion.identity);
        Rigidbody2D arrowRigidbody = spawnedArrow.GetComponent<Rigidbody2D>();
        arrowRigidbody.linearVelocity = new Vector2(20, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
