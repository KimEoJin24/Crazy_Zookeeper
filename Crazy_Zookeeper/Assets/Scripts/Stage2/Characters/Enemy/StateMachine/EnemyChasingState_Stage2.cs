using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState_Stage2 : EnemyBaseState_Stage2
{
    public EnemyChasingState_Stage2(EnemyStateMachine_Stage2 ememyStateMachine) : base(ememyStateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();

        //if (!IsInChaseRange())
        //{
        //    stateMachine.ChangeState(stateMachine.IdlingState);
        //    return;
        //}
       
    }

    
}