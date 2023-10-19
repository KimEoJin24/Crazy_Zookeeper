using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hippo : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public GameObject gameOverUI;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        HippoConditions.Instance.TakePhysicalDamage(damageAmount);
        if (HP <= 0)
        {
            animator.SetTrigger("Die");
            Debug.Log(HP + "Hippo Die");
            gameOverUI.gameObject.SetActive(true);
        }
        else
        {
            animator.SetTrigger("Damage");
            Debug.Log(HP + "Hippo Damage");
        }
    }

    public void PickItem(int hp)
    {
        
    }
}
