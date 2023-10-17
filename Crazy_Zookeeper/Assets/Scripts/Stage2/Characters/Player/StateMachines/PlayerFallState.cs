using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }


    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Controller.isGrounded)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
    }
}