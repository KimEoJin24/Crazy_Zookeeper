using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zookeeper : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;

    Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bat")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage;
        }
    }
}
