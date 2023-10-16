using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float drag = 0.3f;

    private Vector3 dampingVelocity;
    private Vector3 impact; // 추가적인 힘
    private float verticalVelocity;

    public Vector3 Movement => impact + Vector3.up * verticalVelocity;

    void Update()
    {
        if (verticalVelocity < 0f && controller.isGrounded) // 바닥에 붙어있으면
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime; 
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; // 바닥이 아니면 중력 증가
        }

        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag); // impact -> 0 감소
    }

    public void Reset() // 떨어지면 힘 제거
    {
        impact = Vector3.zero;
        verticalVelocity = 0f;
    }

    public void AddForce(Vector3 force) 
    {
        impact += force;
    }

    public void Jump(float jumpForce)
    {
        verticalVelocity += jumpForce;
    }
}