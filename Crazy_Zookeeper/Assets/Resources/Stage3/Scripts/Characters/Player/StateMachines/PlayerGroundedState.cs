using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!stateMachine.Player.Controller.isGrounded // 바닥이 아닐 때
        && stateMachine.Player.Controller.velocity.y < Physics.gravity.y * Time.fixedDeltaTime) // 빠른 속도로 떨어질 때
        {
            stateMachine.ChangeState(stateMachine.FallState); // 떨어지기O
            return;
        }
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if (stateMachine.MovementInput == Vector2.zero) // 입력 없음
        {
            return;
        }

        stateMachine.ChangeState(stateMachine.IdleState); // 입력 취소: 이동키 -> Idle 전환

        base.OnMovementCanceled(context);
    }

    protected override void OnJumpStarted(InputAction.CallbackContext obj) // 점프 키가 눌러졌을 때
    {
        stateMachine.ChangeState(stateMachine.JumpState); // 점프로 전환
    }

    protected virtual void OnMove() // 이동이 이루어짐.
    {
        stateMachine.ChangeState(stateMachine.WalkState); // 걷기로 전환
    }

}