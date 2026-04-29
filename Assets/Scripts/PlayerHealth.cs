using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        if (GameManager.instance != null)
            GameManager.instance.UpdateHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (GameManager.instance != null)
            GameManager.instance.UpdateHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        CameraShake.instance.Shake(0.15f, 0.2f);
    }

    void Die()
    {
        Debug.Log("Player Died!");
        Time.timeScale = 0f;
        if (GameManager.instance != null)
            GameManager.instance.GameOver();
    }
}