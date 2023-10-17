using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public float PlayerChasingSpeed { get; private set; } = 9f;
    [field: SerializeField] public float IdleSpeed { get; private set; } = 5f;
    [field: SerializeField][field: Range(0f, 3f)] public float ForceTransitionTime { get; private set; }
    [field: SerializeField][field: Range(-10f, 10f)] public float Force { get; private set; }

    [field: SerializeField] public PlayerGroundData GroundedData { get; private set; }
}