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

    // 다른 스크립트에서 접근하기 위한 프로퍼티
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

    // TODO: 공격 기능에 따른 스태미나 감소 구현
    public void Die()
    {
        Debug.Log("하마가 쓰러졌다.");
    }

    // TODO: 사육사 공격 종류에 따른 데미지 값 감소 구현
    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }

    // TODO: UpdateUI 메서드 
    void UpdateUI()
    {
        health.uiBar.fillAmount = health.GetPercentage();
    }
}
