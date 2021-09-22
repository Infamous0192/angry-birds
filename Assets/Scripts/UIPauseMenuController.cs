using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject gameplayPanel;
    public Text statusInfo;
    public Button buttonResume;
    public Button buttonRestart;
    public Button buttonChangeLevel;
    public Button buttonExit;

    private void Start()
    {
        buttonResume.onClick.AddListener(ResumeGame);
        buttonRestart.onClick.AddListener(RestartGame);
        buttonChangeLevel.onClick.AddListener(ChangeLevel);
        buttonExit.onClick.AddListener(ExitToMenu);
        pauseMenuPanel.gameObject.SetActive(false);
    }

    public void EndGame(bool isWin)
    {
        buttonResume.gameObject.SetActive(false);
        statusInfo.text = isWin ? "YOU WIN!" : "YOU LOSE!";
        gameplayPanel.SetActive(false);
        pauseMenuPanel.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuPanel.gameObject.SetActive(true);
        statusInfo.text = "GAME PAUSED";
        gameplayPanel.SetActive(false);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuPanel.gameObject.SetActive(false);
        gameplayPanel.SetActive(true);
    }

    public void RestartGame()
    {
        GameController.IsGameEnded = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    
    private void ExitToMenu()
    {
        Application.Quit();
    }
}
