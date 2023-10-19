using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zookeeper : MonoBehaviour
{
    private int HP = 100;
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
        //ZookeeperConditions.Instance.TakePhysicalDamage(damageAmount);
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

        UpdateHealthBar(); // ������ �Ծ��� �� HP�� ������Ʈ
    }
}
