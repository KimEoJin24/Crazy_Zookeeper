using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuUI;

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(menuUI.activeSelf)
            {
                menuUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                menuUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("StartScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
