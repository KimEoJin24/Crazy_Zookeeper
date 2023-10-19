using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private GameObject panelStageClear;
    private int maxPointCount;
    private int currentPointCount;
    private bool getAllPoints = false;

    public int MaxPointCount => maxPointCount;
    public int CurrentPointCount => currentPointCount;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        panelStageClear.SetActive(false);
        maxPointCount = GameObject.FindGameObjectsWithTag("Point").Length;
        currentPointCount = maxPointCount;
    }
    private void Update()
    {
        if( getAllPoints == true)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
    public void GetPoint()
    {
        currentPointCount--;
        if ( currentPointCount == 0)
        {
            getAllPoints = true;
            Time.timeScale = 1.0f;
            panelStageClear.SetActive(true);
        }
    }
}
