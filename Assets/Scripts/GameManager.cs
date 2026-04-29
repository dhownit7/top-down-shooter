using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    private int highScore = 0;

    public TextMeshProUGUI waveNotificationText;

    public void ShowWaveNotification(int wave)
    {
        StartCoroutine(WaveNotificationCoroutine(wave));
    }

    IEnumerator WaveNotificationCoroutine(int wave)
    {
        waveNotificationText.gameObject.SetActive(true);
        waveNotificationText.text = "WAVE " + wave;
        yield return new WaitForSeconds(2f);
        waveNotificationText.gameObject.SetActive(false);
    }

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (gameOverText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }
    }

    public void UpdateHealth(int health)
    {
        healthText.text = "HP: " + health;
    }

    public void UpdateWave(int wave)
    {
        waveText.text = "Wave: " + wave;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score + "\nHigh: " + highScore;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    void Start()
    {
        scoreText.text = "Score: 0\nHigh: " + highScore;
    }

}