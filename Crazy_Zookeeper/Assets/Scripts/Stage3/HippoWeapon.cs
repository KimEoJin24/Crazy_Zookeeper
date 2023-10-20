using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippoWeapon : MonoBehaviour
{
    public int damageAmont = 20;
    public AudioSource attackSound;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zookeeper")
        {
            attackSound.Play();
            other.GetComponent<Zookeeper>().TakeDamage(damageAmont);
        }
    }
}
