using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZookeeperDamageController : MonoBehaviour
{
    public int damage;
    public float damageRate;

    private List<IDamagable> _thingsToDamage = new List<IDamagable>();
    private void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        for (int i = 0; i < _thingsToDamage.Count; i++)
        {
            _thingsToDamage[i].TakePhysicalDamage(damage);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            _thingsToDamage.Add(damagable);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            _thingsToDamage.Remove(damagable);
        }
    }
}
