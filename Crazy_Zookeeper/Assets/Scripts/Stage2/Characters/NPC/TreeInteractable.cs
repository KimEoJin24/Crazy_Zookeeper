using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractable : MonoBehaviour
{
    public GameObject cutTree;
    public GameObject originalTree;
    public GameObject player;
    public float interactionDistance = 2f;
    private int capacity = 10;
    void Start()
    {
        
    }
    public void Interact()
    {
        capacity -= 1;
        if(capacity <= 0) { TreeCut(); }
    }
    public void TreeCut()
    {
        originalTree.SetActive(false);
        cutTree.SetActive(true);
        GameManager_Stage2.instance.GameClear();
    }
}
