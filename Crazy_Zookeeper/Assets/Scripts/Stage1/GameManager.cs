using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private GameObject panelStageClear;
    private float GameTime = 120;
    public Text GameTimeText;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        panelStageClear.SetActive(false);
    }
        private void Update()
    {
      
        if((int)GameTime ==0)
        {
            Debug.Log("게임종료");
            Time.timeScale = 0.0f;
            panelStageClear.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }

        else
        {
            GameTime -= Time.deltaTime;
            Debug.Log((int)GameTime);
            GameTimeText.text = "Time: " + (int)GameTime;
        }
    }
}
