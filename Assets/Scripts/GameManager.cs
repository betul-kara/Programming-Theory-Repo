using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] int startDelay;
    [SerializeField] int spawnInterval;
    [SerializeField] Text gameOverText;
    //[SerializeField] Text endLevelText;
    static int spawnRangeX = 5;
    static int spawnZ = 195;
    bool isGameActive;
    private void Start()
    {
        isGameActive = true;
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }
    private void Update()
    {
        CheckHealth();
    }
    public void SpawnEnemy()
    {
        if (isGameActive)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnZ);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void CheckHealth()
    {
        if (PlayerController.Health < 0)
        {
            GameOver();
        }
    }
}