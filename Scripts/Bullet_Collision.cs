using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : MonoBehaviour
{
    public ParticleSystem ShootEff; 
    public AudioClip bulletHit;

    AudioSource ads;

    void Start()
    {
        ads = GetComponent<AudioSource>();    
    }
    void OnCollisionEnter(Collision other) 
    {
       
       switch(other.gameObject.tag)
       {
        case "Player":
        break;

        case "Enemy":
        EnemyEff();
        break;

        }

    }

    void EnemyEff()
    {
        ShootEff.Play();
        ads.PlayOneShot(bulletHit);

    }
}
