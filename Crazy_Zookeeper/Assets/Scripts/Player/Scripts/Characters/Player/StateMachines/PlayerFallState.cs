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

        StartAnimation(stateMachine.Player.AnimationData.fallParameterHash); // ¶³¾îÁö±â O
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.fallParameterHash); // ¶³¾îÁö±â X
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Controller.isGrounded) // ¹Ù´Ú¿¡ ´êÀ¸¸é
        {
            stateMachine.ChangeState(stateMachine.IdleState); // Idle·Î ÀüÈ¯
            return;
        }
    }
}