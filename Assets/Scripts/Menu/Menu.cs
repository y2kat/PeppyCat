using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        Time.timeScale = 1.0f;
        level.SetActive(true);
        menu.SetActive(false);
    }

    public void quitGame()
    {
        Debug.Log("Saliste");
        Application.Quit();
    }

    public void returnToMenu()
    {
        Time.timeScale = 1.0f; 
        level.SetActive(false);
        menu.SetActive(true);
        deathPanel.SetActive(false);
    }

    public void showDeathScreen()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        int highScore = PlayerPrefs.GetInt("Highscore", 0);

        scoreText.text = "Score: " + score;
        highScoreText.text = "Highscore: " + highScore;

        deathPanel.SetActive(true);
    }
}
