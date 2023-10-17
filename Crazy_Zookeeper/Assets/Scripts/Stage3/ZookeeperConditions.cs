using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZookeeperConditions : MonoBehaviour, IDamagable
{
    public Condition conditions;
    public Condition health;
    public UnityEvent onTakeDamage;

    // Start is called before the first frame update
    void Start()
    {
        health.curValue = health.startValue;
    }

    // Update is called once per frame
    void Update()
    {
        health.uiBar.fillAmount = health.GetPercentage();
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("하마가 죽었다.");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        throw new System.NotImplementedException();
    }
}
