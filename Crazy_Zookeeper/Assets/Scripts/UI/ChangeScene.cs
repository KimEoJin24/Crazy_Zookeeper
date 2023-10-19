using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StartSceneLoadButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Stage1SceneLoadButton()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2SceneLoadButton()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3SceneLoadButton()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
