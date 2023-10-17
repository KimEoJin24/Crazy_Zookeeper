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

        if (!stateMachine.Player.Controller.isGrounded // �ٴ��� �ƴ� ��
        && stateMachine.Player.Controller.velocity.y < Physics.gravity.y * Time.fixedDeltaTime) // ���� �ӵ��� ������ ��
        {
            stateMachine.ChangeState(stateMachine.FallState); // ��������O
            return;
        }
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if (stateMachine.MovementInput == Vector2.zero) // �Է� ����
        {
            return;
        }

        stateMachine.ChangeState(stateMachine.IdleState); // �Է� ���: �̵�Ű -> Idle ��ȯ

        base.OnMovementCanceled(context);
    }

    protected override void OnJumpStarted(InputAction.CallbackContext obj) // ���� Ű�� �������� ��
    {
        stateMachine.ChangeState(stateMachine.JumpState); // ������ ��ȯ
    }

    protected virtual void OnMove() // �̵��� �̷����.
    {
        stateMachine.ChangeState(stateMachine.WalkState); // �ȱ�� ��ȯ
    }

}