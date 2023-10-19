using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Stage2 : MonoBehaviour
{
    public static GameManager_Stage2 instance;
    public GameObject Player;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }
    public void GameClear()
    {
        Time.timeScale = 0;
        //UIÆ²±â
        SceneManager.LoadScene("Stage3");
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("StartScene");
    }
}
