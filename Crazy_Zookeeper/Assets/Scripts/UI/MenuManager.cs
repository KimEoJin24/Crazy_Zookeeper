using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuUI;
    public static bool menuUITF = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuUITF == false)
        {
            Time.timeScale = 0.0f;
            menuUI.SetActive(true);
            menuUITF = true;
        }
    }
    
    public void PlayButton()
    {
        Time.timeScale = 1.0f;
        menuUI.SetActive(false);
        menuUITF = false;   
    }

    public void ExitButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScene");
        menuUI.SetActive(false);   
        menuUITF = false;   
    }

}
