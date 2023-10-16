using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGroundData
{
    [field: SerializeField] [field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f; // 기본 속도
    [field: SerializeField] [field: Range(0f, 25f)] public float BaseRotationDamping { get; private set; } = 1f; // 기본 회전

    [field: Header("IdleData")]

    [field: Header("WalkData")]
    [field: SerializeField] [field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.225f; // 걷는 속도

    [field: Header("RunData")]
    [field: SerializeField] [field: Range(0f, 2f)] public float RunSpeedModifier { get; private set; } = 1f; // 달리는 속도
}