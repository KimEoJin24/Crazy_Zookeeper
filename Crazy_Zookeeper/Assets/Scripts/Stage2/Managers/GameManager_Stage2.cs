using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager_Stage2 : MonoBehaviour
{
    public static GameManager_Stage2 instance;
    public GameObject Player;
    public GameObject Axe;
    public GameObject menuUI;
    public Button continueBtn;
    public Button exitBtn;

    private bool isMenuActive = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Axe.SetActive(false);
    }
    public void GameClear()
    {
        Time.timeScale = 0;
        //UIÆ²±â
        SceneManager.LoadScene("BossIntroScene");
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("StartScene");
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }
    public void ResumeGame()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
    public void ExitGame()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("StartScene");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
                menuUI.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                UnityEngine.Cursor.visible = true;
                menuUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
