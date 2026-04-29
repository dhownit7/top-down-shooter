using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 3f;
    public float spawnRate = 0.5f;

    private int currentWave = 0;
    private int enemiesAlive = 0;
    private bool waveInProgress = false;

    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        while (true)
        {
            currentWave++;
            if (GameManager.instance != null)
                GameManager.instance.UpdateWave(currentWave);

            Debug.Log("Wave " + currentWave + " starting!");

            yield return new WaitForSeconds(timeBetweenWaves);

            // Spawn enemies
            int enemiesToSpawn = enemiesPerWave + (currentWave - 1) * 2;
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnRate);
            }

            // Wait until all enemies are dead
            while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}