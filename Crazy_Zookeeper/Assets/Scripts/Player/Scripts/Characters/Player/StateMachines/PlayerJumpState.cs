using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.JumpForce = stateMachine.Player.Data.AirData.JumpForce;
        stateMachine.Player.ForceReceiver.Jump(stateMachine.JumpForce); // 점프 힘 

        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.JumpParameterHash); // 점프 O
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.JumpParameterHash); // 점프 X
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (stateMachine.Player.Controller.velocity.y <= 0) // 떨어지는 시점
        {
            stateMachine.ChangeState(stateMachine.FallState); // 떨어지기 전환
            return;
        }
    }
}