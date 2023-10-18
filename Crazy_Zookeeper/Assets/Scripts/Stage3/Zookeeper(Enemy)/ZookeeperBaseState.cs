using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZookeeperBaseState : IState
{
    protected ZookeeperStateMachine stateMachine;

    protected readonly PlayerGroundData groundData;
    public ZookeeperBaseState(ZookeeperStateMachine zookeeperStateMachine)
    {
        stateMachine = zookeeperStateMachine;
        groundData = stateMachine.Zookeeper.Data.GroundedData;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void Update()
    {
        Move();
    }

    public virtual void PhysicsUpdate()
    {

    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Zookeeper.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Zookeeper.Animator.SetBool(animationHash, false);
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);
        Move(movementDirection);
    }

    protected void ForceMove()
    {
        stateMachine.Zookeeper.Controller.Move(stateMachine.Zookeeper.ForceReceiver.Movement * Time.deltaTime);
    }

    // 
    private Vector3 GetMovementDirection()
    {
        return (stateMachine.Target.transform.position - stateMachine.Zookeeper.transform.position).normalized;
    }

    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Zookeeper.Controller.Move(((direction * movementSpeed) + stateMachine.Zookeeper.ForceReceiver.Movement) * Time.deltaTime);
    }

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            stateMachine.Zookeeper.transform.rotation = Quaternion.Slerp(stateMachine.Zookeeper.transform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    protected float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        return movementSpeed;
    }

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }

    //
    protected bool IsInChaseRange()
    {
        // if (stateMachine.Target.IsDead) { return false; }

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Zookeeper.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.Zookeeper.Data.PlayerChasingRange * stateMachine.Zookeeper.Data.PlayerChasingRange;
    }
}