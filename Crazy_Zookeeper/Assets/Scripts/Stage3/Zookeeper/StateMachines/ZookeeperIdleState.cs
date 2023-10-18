using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZookeeperIdleState : ZookeeperBaseState
{
    public ZookeeperIdleState(ZookeeperStateMachine zookeeperStateMachine) : base(zookeeperStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;

        base.Enter();
        StartAnimation(stateMachine.Zookeeper.AnimationData.GroundParameterHash); 
        StartAnimation(stateMachine.Zookeeper.AnimationData.IdleParameterHash); // Idle O
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Zookeeper.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.Zookeeper.AnimationData.IdleParameterHash); // Idle X
    }

    public override void Update()
    {
        if (IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }
}