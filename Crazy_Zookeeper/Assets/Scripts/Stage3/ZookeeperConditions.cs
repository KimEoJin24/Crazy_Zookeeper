using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZookeeperConditions : MonoBehaviour, IDamagable
{
    public Condition conditions;
    public Condition health;
    public Action onTakeDamage;

    private static ZookeeperConditions instance;

    // �ٸ� ��ũ��Ʈ���� �����ϱ� ���� ������Ƽ
    public static ZookeeperConditions Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ZookeeperConditions>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("ZookeeperConditions");
                    instance = singletonObject.AddComponent<ZookeeperConditions>();
                }
            }
            return instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        health.curValue = health.startValue;
        onTakeDamage += UpdateUI;
    }


    // TODO: ������ ��ų �� ü�� ȸ�� ��ų ���� ��� ���� ����
    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("�����簡 ��������.");
    }

    // TODO: �ϸ� ���� ������ ���� ������ �� ���� ����
    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }

    // TODO: UpdateUI �޼���
    void UpdateUI()
    {
        health.uiBar.fillAmount = health.GetPercentage();
    }
}
