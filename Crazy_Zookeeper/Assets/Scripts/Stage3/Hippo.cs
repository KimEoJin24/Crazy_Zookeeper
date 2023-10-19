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
            Destroy(other.gameObject); // "Green" �������� �Ծ����Ƿ� �ش� ������Ʈ�� ����
        }
        else if (other.tag == "Blue")
        {
            IncreaseHealth(30);
            Destroy(other.gameObject); // "Blue" �������� �Ծ����Ƿ� �ش� ������Ʈ�� ����
        }
        else if (other.CompareTag("Red"))
        {
            IncreaseHealth(40);
            Destroy(other.gameObject); // "Red" �������� �Ծ����Ƿ� �ش� ������Ʈ�� ����
        }
    }

    private void IncreaseHealth(int amount)
    {
        HP += amount;
        HippoConditions.Instance.HealthFilling(amount);
        Debug.Log("Hippo's HP increased by " + amount + ". Current HP: " + HP);
    }
}
