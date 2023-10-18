using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZookeeperStateMachine : StateMachine
{
    public Zookeeper Zookeeper { get; }

    public Transform Target { get; private set; }

    public ZookeeperIdleState IdlingState { get; }
    public ZookeeperChasingState ChasingState { get; }
    public ZookeeperAttackState AttackState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public ZookeeperStateMachine(Zookeeper zookeeper)
    {
        Zookeeper = zookeeper;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        IdlingState = new ZookeeperIdleState(this);
        ChasingState = new ZookeeperChasingState(this);
        AttackState = new ZookeeperAttackState(this);

        MovementSpeed = Zookeeper.Data.GroundedData.BaseSpeed;
        RotationDamping = Zookeeper.Data.GroundedData.BaseRotationDamping;
    }
}