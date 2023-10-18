using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZookeeperWeapon : MonoBehaviour
{
    public int damageAmont = 20;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Hippo>().TakeDamage(damageAmont);
        }
    }
}
