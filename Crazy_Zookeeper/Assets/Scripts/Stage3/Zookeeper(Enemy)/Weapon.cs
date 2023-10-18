using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    public enum Type { Bat, Sword };
    public Type type;
    public int damage;
    public float rate;
    public CapsuleCollider batArea;
    public TrailRenderer traileEffect;

    private void Update()
    {
        Use();
    }

    public void Use()
    {
        if (stateMachine.IsAttacking)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f);
        batArea.enabled = true;
        traileEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        batArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        traileEffect.enabled = false;
    }
}
