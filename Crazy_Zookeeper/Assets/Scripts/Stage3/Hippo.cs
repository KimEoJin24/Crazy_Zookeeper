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
            GetComponent<Collider>().enabled = false;
            Debug.Log(HP + "Hippo Die");
            gameOverUI.gameObject.SetActive(true);
        }
        else
        {
            animator.SetTrigger("Damage");
            Debug.Log(HP + "Hippo Damage");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Green")
        {
            IncreaseHealth(20);
            Destroy(other.gameObject); // "Green" 아이템을 먹었으므로 해당 오브젝트를 제거
        }
        else if (other.tag == "Blue")
        {
            IncreaseHealth(30);
            Destroy(other.gameObject); // "Blue" 아이템을 먹었으므로 해당 오브젝트를 제거
        }
        else if (other.CompareTag("Red"))
        {
            IncreaseHealth(40);
            Destroy(other.gameObject); // "Red" 아이템을 먹었으므로 해당 오브젝트를 제거
        }
    }

    private void IncreaseHealth(int amount)
    {
        HP += amount;
        HippoConditions.Instance.HealthFilling(amount);
        Debug.Log("Hippo's HP increased by " + amount + ". Current HP: " + HP);
    }
}
