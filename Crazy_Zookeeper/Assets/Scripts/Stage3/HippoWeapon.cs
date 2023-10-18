using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippoWeapon : MonoBehaviour
{
    public int damageAmont = 20;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zookeeper")
        {
            other.GetComponent<Zookeeper>().TakeDamage(damageAmont);
        }
    }
}
