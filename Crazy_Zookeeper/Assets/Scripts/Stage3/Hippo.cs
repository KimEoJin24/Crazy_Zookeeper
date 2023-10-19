using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hippo : MonoBehaviour
{
    public int HP = 100;
    private int maxHP = 100; // �ִ밪(100���� ����)

    public Animator animator;
    public Image healthBar;

    private void Start()
    {
        UpdateHealthBar(); // ���� ���� �� HP�� �ʱ�ȭ
    }

    private void Update()
    {
        UpdateHealthBar(); // HP�� 0���� 1�� ����ȭ�Ͽ� HP�� ������Ʈ
    }
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)HP / maxHP; // ����ȭ�� ������ HP�� ������Ʈ
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        HippoConditions.Instance.TakePhysicalDamage(damageAmount);
        if (HP <= 0)
        {
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
            Debug.Log(HP + "Hippo Die");
        }
        else
        {
            animator.SetTrigger("Damage");
            Debug.Log(HP + "Hippo Damage");
        }

        UpdateHealthBar(); // ������ �Ծ��� �� HP�� ������Ʈ
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            IncreaseHealth(20);
            Destroy(other.gameObject); // "Green" �������� �Ծ����Ƿ� �ش� ������Ʈ�� ����
        }
        else if (other.CompareTag("Blue"))
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
        Debug.Log("Hippo's HP increased by " + amount + ". Current HP: " + HP);
    }
}
