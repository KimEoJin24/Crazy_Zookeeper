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
        if (Input.GetKeyDown(KeyCode.Tab) && menuUITF == false)
        {
            menuUI.SetActive(true);
        }
    }
    
    public void PlayButton()
    {
        menuUI.SetActive(false);
        menuUITF = false;   
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("StartScene");
        menuUI.SetActive(false);   
        menuUITF = false;   
    }

}
