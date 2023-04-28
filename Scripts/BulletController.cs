using UnityEngine;


    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 10f;
       
        private void FixedUpdate()
        {
            transform.position += transform.forward * bulletSpeed * Time.fixedDeltaTime;
        }

        public void SetDirection(Vector3 direction)
        {
            transform.forward = direction;
        }

        private void DestroyBullet()
    {
        Destroy(gameObject);
    }
         public void OnCollisionEnter(Collision other)
       {
        switch (other.gameObject.tag)
        {
            case "Walls":
                DestroyBullet(); 
                break;

            default:
                Debug.Log("Unknown tag: " + other.gameObject.tag);
                break;
        }
    }
    }