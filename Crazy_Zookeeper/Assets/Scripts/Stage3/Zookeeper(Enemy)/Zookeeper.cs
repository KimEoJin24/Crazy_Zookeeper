using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zookeeper : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        ZookeeperConditions.Instance.TakePhysicalDamage(damageAmount);
        if (HP <= 0)
        {
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
            Debug.Log(HP + "Die");
        }
        else
        {
            animator.SetTrigger("Damage");
            Debug.Log(HP + "Damage");
        }

    }
}

