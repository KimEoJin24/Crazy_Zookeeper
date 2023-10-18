using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState_Stage2 : EnemyBaseState_Stage2
{
    public EnemyIdleState_Stage2(EnemyStateMachine_Stage2 ememyStateMachine) : base(ememyStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;

        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        //if (IsInChaseRange())
        //{
        //    stateMachine.ChangeState(stateMachine.ChasingState);
        //    return;
        //}
    }
}
