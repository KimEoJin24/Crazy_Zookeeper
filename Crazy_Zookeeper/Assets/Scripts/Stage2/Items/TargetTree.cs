using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTree : MonoBehaviour
{
    public GameObject Tree;
    public bool isTreeCut;
    public int quantityPerHit = 1;
    public int capacity;

    public void Hit(Vector3 hitPoint, Vector3 hitNormal)
    {
        for (int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) { break; }
            capacity -= 1;
        }
        if(capacity<=0)
            GameManager_Stage2.instance.GameClear();           
    }
}
