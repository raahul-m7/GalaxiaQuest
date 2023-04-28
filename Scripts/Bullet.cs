using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 2f;
    public bool CollisionDisable = false;
    public int bulletCount = 0;


    
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision other)
    {
        
        switch (other.gameObject.tag)
        {
            case "Player":
                CollisionDisable = !CollisionDisable;
                break;

            case "enemy":
                Destroy(other.gameObject, 0.25f);
                Destroy(gameObject);
               
                break;

            case "Walls":
                Invoke("DestroyBullet",life); 
                break;

            case "bullet_enemy":
                Destroy(other.gameObject, 0.25f);
                break;

            default:
                Debug.Log("Unknown tag: " + other.gameObject.tag);
                break;
        }
    }
}
