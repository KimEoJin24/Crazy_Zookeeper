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

    void Start()
    {
        health.curValue = health.startValue;
        onTakeDamage += UpdateUI;
    }

    public void Die()
    {
        Debug.Log("사육사가 쓰러졌다.");
    }


    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }

    void UpdateUI()
    {
        health.uiBar.fillAmount = health.GetPercentage();
    }
}
