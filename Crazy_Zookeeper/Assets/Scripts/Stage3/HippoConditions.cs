using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

[System.Serializable]
public class Condition
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar;

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}

public class HippoConditions : MonoBehaviour, IDamagable
{
    public Condition health;
    public Condition stamina;

    public Action onTakeDamage;

    private static HippoConditions instance;

    // �ٸ� ��ũ��Ʈ���� �����ϱ� ���� ������Ƽ
    public static HippoConditions Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HippoConditions>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("HippoConditions");
                    instance = singletonObject.AddComponent<HippoConditions>();
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


    public void HealthFilling(float amount)
    {
        health.Add(amount);
        onTakeDamage?.Invoke();
    }

    public void StaminaFilling(float amount)
    {
        stamina.Add(amount);
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0)
        {
            return false;
        }

        stamina.Subtract(amount);
        return true;
    }

    // TODO: ���� ��ɿ� ���� ���¹̳� ���� ����
    public void Die()
    {
        Debug.Log("�ϸ��� ��������.");
    }

    // TODO: ������ ���� ������ ���� ������ �� ���� ����
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
