using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZookeeperAttackState : ZookeeperBaseState
{

    private bool alreadyAppliedForce;

    public ZookeeperAttackState(ZookeeperStateMachine zookeeperStateMachine) : base(zookeeperStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;
        base.Enter();
        StartAnimation(stateMachine.Zookeeper.AnimationData.AttackParameterHash);
        StartAnimation(stateMachine.Zookeeper.AnimationData.BaseAttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Zookeeper.AnimationData.AttackParameterHash);
        StopAnimation(stateMachine.Zookeeper.AnimationData.BaseAttackParameterHash);

    }

    public override void Update()
    {
        base.Update();

        ForceMove();

        float normalizedTime = GetNormalizedTime(stateMachine.Zookeeper.Animator, "Attack");
        if (normalizedTime < 1f)
        {
            if (normalizedTime >= stateMachine.Zookeeper.Data.ForceTransitionTime)
                TryApplyForce();

        }
        else
        {
            if (IsInChaseRange())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
                return;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdlingState);
                return;
            }
        }

    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        stateMachine.Zookeeper.ForceReceiver.Reset();

        stateMachine.Zookeeper.ForceReceiver.AddForce(stateMachine.Zookeeper.transform.forward * stateMachine.Zookeeper.Data.Force);

    }
}