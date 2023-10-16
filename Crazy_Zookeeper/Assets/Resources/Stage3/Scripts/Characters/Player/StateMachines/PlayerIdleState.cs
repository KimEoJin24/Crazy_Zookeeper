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
        stateMachine.MovementSpeedModifier = 0f; // �ӵ�0
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
        if(stateMachine.MovementInput != Vector2.zero) // �̵��Ѵٸ�
        {
            OnMove(); // �ȱ� ��ȯ
            return;
        }
    }
}