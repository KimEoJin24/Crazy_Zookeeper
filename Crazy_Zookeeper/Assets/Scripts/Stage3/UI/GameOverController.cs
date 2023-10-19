using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
