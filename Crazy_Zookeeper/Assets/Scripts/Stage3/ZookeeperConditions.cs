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

    private static ZookeeperConditions instance;

    // 다른 스크립트에서 접근하기 위한 프로퍼티
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
    }

    // Update is called once per frame
    void Update()
    {
        health.uiBar.fillAmount = health.GetPercentage();
    }

    // TODO: 사육사 스킬 중 체력 회복 스킬 없을 경우 삭제 예정
    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("사육사가 쓰러졌다.");
    }

    // TODO: 하마 공격 종류에 따른 데미지 값 감소 구현
    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }

    // TODO: UpdateUI 메서드
}
