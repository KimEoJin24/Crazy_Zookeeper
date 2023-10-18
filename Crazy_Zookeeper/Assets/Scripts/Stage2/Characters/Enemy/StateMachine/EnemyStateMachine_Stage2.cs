using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine_Stage2 : StateMachine
{
    public Enemy_Stage2 Enemy { get; }

    public CharacterHealth_Stage2 Target { get; private set; }

    public EnemyIdleState_Stage2 IdlingState { get; }
    public EnemyChasingState_Stage2 ChasingState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public EnemyStateMachine_Stage2(Enemy_Stage2 enemy)
    {
        Enemy = enemy;

        IdlingState = new EnemyIdleState_Stage2(this);
        ChasingState = new EnemyChasingState_Stage2(this);

        MovementSpeed = enemy.Data.GroundedData.BaseSpeed;
        RotationDamping = enemy.Data.GroundedData.BaseRotationDamping;
    }
}