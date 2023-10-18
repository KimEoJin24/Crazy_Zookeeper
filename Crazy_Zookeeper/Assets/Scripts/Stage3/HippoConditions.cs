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
    [HideInInspector]
    [SerializeField]
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

    public UnityEvent onTakeDamage;
    // Start is called before the first frame update
    void Start()
    {
        health.curValue = health.startValue;
        stamina.curValue = stamina.startValue;
    }

    // Update is called once per frame
    void Update()
    {
        stamina.Add(stamina.regenRate * Time.deltaTime);

        health.uiBar.fillAmount = health.GetPercentage();
        stamina.uiBar.fillAmount = stamina.GetPercentage();
    }

    public void HealthFilling(float amount)
    {
        health.Add(amount);
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
}
