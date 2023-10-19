using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zookeeper : MonoBehaviour
{
    private int HP = 100;
    private int maxHP = 100; // 최대값(100으로 설정)

    public Animator animator;
    public Image healthBar;

    private void Start()
    {
        UpdateHealthBar(); // 게임 시작 시 HP바 초기화
    }

    private void Update()
    {
        UpdateHealthBar(); // HP를 0에서 1로 정규화하여 HP바 업데이트
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)HP / maxHP; // 정규화한 값으로 HP바 업데이트
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

        UpdateHealthBar(); // 데미지 입었을 때 HP바 업데이트
    }
}
