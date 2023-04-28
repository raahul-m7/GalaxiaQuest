using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float chaseRange = 10f;
    
    public float hitLimit = 5.0f;
    int hitCount = 0;
    Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("Bullet"))
            {
                hitCount++;
                if (hitCount < hitLimit)
                {
                    Destroy(gameObject);
                }
            }
        }
    void Update()
    {
        // Calculate the distance from the enemy to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the chase range
        if (distanceToPlayer <= chaseRange)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = player.position - transform.position;

            // Rotate the enemy to face the player
            transform.rotation = Quaternion.LookRotation(direction);

            // Move the enemy towards the player
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
