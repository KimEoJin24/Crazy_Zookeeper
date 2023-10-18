using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZookeeperChasingState : ZookeeperBaseState
{
    public ZookeeperChasingState(ZookeeperStateMachine zookeeperStateMachine) : base(zookeeperStateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1;
        base.Enter();
        StartAnimation(stateMachine.Zookeeper.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.Zookeeper.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Zookeeper.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.Zookeeper.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
    }

    private bool IsInAttackRange()
    {
        // if (stateMachine.Target.IsDead) { return false; }

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Zookeeper.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.Zookeeper.Data.AttackRange * stateMachine.Zookeeper.Data.AttackRange;
    }
}