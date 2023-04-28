using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycollision : MonoBehaviour
{
    [SerializeField] AudioClip boom;

    [SerializeField] ParticleSystem boomeff;

    AudioSource ads;

void Start() 
    {
        ads = GetComponent<AudioSource>();
        ads.Stop();
    }


void OnCollisionEnter(Collision other)
    {
       
       boomeff.Play();
       ads.PlayOneShot(boom);
    }
}
