using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI gameOverText;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
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
}