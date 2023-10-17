using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        groundData = stateMachine.Player.Data.GroundedData;
    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    private void AddInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Move.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunStarted;

        stateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.Attack.performed += OnAttackPerformed;
        stateMachine.Player.Input.PlayerActions.Attack.canceled += OnAttackCanceled;
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    private void RemoveInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Move.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunStarted;

        stateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.Attack.performed -= OnAttackPerformed;
        stateMachine.Player.Input.PlayerActions.Attack.canceled -= OnAttackCanceled;
    }

    protected virtual void OnRunStarted(InputAction.CallbackContext obj)
    {
       
    }

    protected virtual void  OnMovementCanceled(InputAction.CallbackContext obj)
    {
        
    }
    protected virtual void OnJumpStarted(InputAction.CallbackContext obj)
    {

    }
    protected void ForceMove()
    {
        stateMachine.Player.Controller.Move(stateMachine.Player.ForceReceiver.Movement * Time.deltaTime);
    }


    protected virtual void OnAttackPerformed(InputAction.CallbackContext obj) // 눌러지는 동안
    {
        stateMachine.IsAttacking = true;
    }

    protected virtual void OnAttackCanceled(InputAction.CallbackContext obj) // 뺄 때는
    {
        stateMachine.IsAttacking = false;
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {
        Move();
    }

    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.Input.PlayerActions.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);

        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.MovementInput.y + right * stateMachine.MovementInput.x;
    }

    private void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovemenetSpeed();
        stateMachine.Player.Controller.Move(
            ((movementDirection * movementSpeed) 
            + stateMachine.Player.ForceReceiver.Movement)
            * Time.deltaTime
            );
    }

    private void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    private float GetMovemenetSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    // 애니메이션
    protected void StartAnimation(int animationHash) // 켜기
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash) // 끄기
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }
    
    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag)) // 라인O & 공격 태크O
        {
            return nextInfo.normalizedTime; // 다음 애니메이션 정보 전달
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag)) // 라인X & 공격 태그O
        {
            return currentInfo.normalizedTime; // 현재 애니메이션 
        }
        else 
        {
            return 0f;
        }
    }

}