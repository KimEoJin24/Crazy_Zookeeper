using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("StartScene");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
