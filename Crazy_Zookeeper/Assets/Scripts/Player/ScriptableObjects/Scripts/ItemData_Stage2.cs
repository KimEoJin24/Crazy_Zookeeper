using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="New Item")]
public class ItemData_Stage2 : ScriptableObject
{
    [Header("Info")]
    public string displayName;

    [Header("IsTaken")]
    public bool isTaken;
}
