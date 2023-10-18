using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZookeeperStateMachine : StateMachine
{
    public Zookeeper Zookeeper { get; }

    public Transform Target { get; private set; }

    // State
    public ZookeeperIdleState IdlingState { get; }
    public ZookeeperChasingState ChasingState { get; }
    public ZookeeperAttackState AttackState { get; }

    // 捞悼 包访 贸府
    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public ZookeeperStateMachine(Zookeeper zookeeper)
    {
        Zookeeper = zookeeper;
        Target = GameObject.FindGameObjectWithTag("Player").transform; // 鸥百

        IdlingState = new ZookeeperIdleState(this);
        ChasingState = new ZookeeperChasingState(this);
        AttackState = new ZookeeperAttackState(this);

        MovementSpeed = zookeeper.Data.GroundedData.BaseSpeed;
        RotationDamping = zookeeper.Data.GroundedData.BaseRotationDamping;
    }
}