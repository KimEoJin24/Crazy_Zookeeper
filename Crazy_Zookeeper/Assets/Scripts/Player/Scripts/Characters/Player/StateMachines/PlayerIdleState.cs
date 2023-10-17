using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f; // 속도0
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash); // Idle O
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.IdleParameterHash); // Idle X
    }

    public override void Update()
    {
        base.Update();
        if(stateMachine.MovementInput != Vector2.zero) // 이동한다면
        {
            OnMove(); // 걷기 전환
            return;
        }
    }
}