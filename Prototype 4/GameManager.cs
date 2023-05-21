using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    private int wavesDeafeated;

        public void UpdateScore(int waveToAdd)
    {
        wavesDeafeated += waveToAdd;
        waveText.text = "Waves Defeated: " + wavesDeafeated;
  
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        wavesDeafeated = 0;
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }

}
