using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundedState
{
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier; // °È´Â ¼Óµµ
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.WalkParameterHash); // °È±âO
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.WalkParameterHash); // °È±âX
    }

    protected override void OnRunStarted(InputAction.CallbackContext context) 
    {
        base.OnRunStarted(context);
        stateMachine.ChangeState(stateMachine.RunState); // ´Þ¸®±â ÀüÈ¯
    }
}