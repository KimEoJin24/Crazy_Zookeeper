using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackInfoData
{
    [field: SerializeField] public string AttackName { get; private set; } // 공격 이름
    [field: SerializeField] public int ComboStateIndex { get; private set; } // 인덱스
    [field: SerializeField] [field: Range(0f, 1f)] public float ComboTransitionTime { get; private set; } // 콤보 유지하려면 언제까지 때려야 하는지
    [field: SerializeField] [field: Range(0f, 3f)] public float ForceTransitionTime { get; private set; } // 언제까지 공격을 누르고 있어야 하는지
    [field: SerializeField] [field: Range(-10f, 10f)] public float Force { get; private set; } // 언제 클릭하면 언제 적용할건지

    [field: SerializeField] public int Damage { get; private set; }
}

[Serializable]
public class PlayerAttackData
{
    [field: SerializeField] public List<AttackInfoData> AttackInfoDatas { get; private set; } // 콤보 종류
    public int GetAttackInfoCount() { return AttackInfoDatas.Count; } // 개수
    public AttackInfoData GetAttackInfo(int index) { return AttackInfoDatas[index]; } // 인덱스에 따른 공격 정보
}
