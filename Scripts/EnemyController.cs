using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField]  float chaseRange = 10.0f;
    [SerializeField]  float shootRange = 5.0f;
    [SerializeField]  float speed = 5.0f;
    [SerializeField]  float shootInterval = 1.0f;
    [SerializeField]  GameObject bulletPrefab;
    [SerializeField]  Transform bulletSpawnPoint;
    [SerializeField]  float bulletSpeed = 5f;
    
    int hitCount = 0;
     bool inShootRange = false;
     float shootTimer = 0.0f;
     Rigidbody rigidbody;

     void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

     void FixedUpdate()
{
    float distanceToPlayer = Vector3.Distance(transform.position, player.position);

    if (!inShootRange)
    {
       ChaseinRange();
    }
    else
    {
        ShootinRange();
    }

    void ShootinRange()
    { 
        rigidbody.velocity = Vector3.zero;

        shootTimer += Time.fixedDeltaTime; // increment the timer

        if (shootTimer >= shootInterval)
        {
            if (bulletPrefab != null && bulletSpawnPoint != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;
                if (bullet != null)
                {
                    bullet.GetComponent<BulletController>().SetDirection(transform.forward);
                }
            }
            shootTimer = 0.0f; // reset the timer
        }
    }

    void ChaseinRange()
    {
         if (distanceToPlayer < chaseRange)
        {
            Vector3 direction = (player.position - bulletSpawnPoint.position).normalized; // Vector3 direction = (player.position - transform.position).normalized;

            rigidbody.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

            if (distanceToPlayer < shootRange)
            {
                inShootRange = true;
                shootTimer = 0.0f; // reset the timer when entering shoot range
            }
        }
    }

    void OnTriggerEnter(Collider other)
        {
            // Check if the object that the bullet collided with has the 'Bullet' tag
            if (other.CompareTag("Bullet"))
            {
                hitCount++;
                // Destroy the bullet if it has hit an object less than 5 times
                if (hitCount < 5)
                {
                    Destroy(gameObject);
                }
                else
                {
                    // Destroy the enemy object if the bullet has hit an object 5 times
                    Destroy(other.transform.parent.gameObject);
                }
            }
        }
}



}

namespace MyGame {

    public class BulletController : MonoBehaviour
    {
        [SerializeField]  float bulletSpeed = 5f;
         int hitCount = 0;

         void FixedUpdate()
        {
            transform.position += transform.forward * bulletSpeed * Time.fixedDeltaTime;
        }

        public void SetDirection(Vector3 direction)
        {
            transform.forward = direction;
        }

        void OnTriggerEnter(Collider other)
        {
            // Destroy the bullet when it hits an object with the 'Walls' tag
            if (other.CompareTag("Walls"))
            {
                Destroy(gameObject);
            }


        }
    }
}
