using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.fallParameterHash); // �������� O
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.fallParameterHash); // �������� X
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Controller.isGrounded) // �ٴڿ� ������
        {
            stateMachine.ChangeState(stateMachine.IdleState); // Idle�� ��ȯ
            return;
        }
    }
}