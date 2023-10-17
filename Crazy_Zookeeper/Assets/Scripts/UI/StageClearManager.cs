using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class StageClearManager : MonoBehaviour
{
    public GameObject[] lockStage;
    public GameObject[] unlockStage;

    enum Clear { UnlockStage2, UnlockStage3 }
    Clear[] clears;

    void Awake()
    {
        clears = (Clear[])Enum.GetValues(typeof(Clear));

        if (!PlayerPrefs.HasKey("Mydata"))
        {
            Init();
        }
    }

    void Init() // 데이터 저장
    {
        PlayerPrefs.SetInt("Mydata", 1);

        foreach (Clear clear in clears)
        {
            PlayerPrefs.SetInt(clear.ToString(), 0);
        }
   
    }

    void Start()
    {
        UnlockStage();
    }

    void UnlockStage()
    {
        for(int index = 0; index < lockStage.Length; index++) 
        {
            string clearName = clears[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(clearName) == 1;
            lockStage[index].SetActive(!isUnlock);
            unlockStage[index].SetActive(isUnlock);
        }
    }

    void LateUpdate()
    {
        foreach (Clear clear in clears) 
        {
            CheckClear(clear);
        }
    }

    void CheckClear(Clear clear)
    {
        bool isClear = false;

        switch (clear)
        {
            case Clear.UnlockStage2:
                // isClear = GameManager_Stage1.instance.clearStage1 == true;
                break;
            case Clear.UnlockStage3:
                // isClear = GameManager_Stage2.instance.clearStage2 == true;
                break;
        }

        if( isClear && PlayerPrefs.GetInt(clear.ToString()) == 0) 
        {
            PlayerPrefs.SetInt(clear.ToString(), 1);
        }
    }
}
