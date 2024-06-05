using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Atributes")]
    [SerializeField] private float enemiesPerSeccond = 0.5f;
    [SerializeField] private int enemiesGroupSize = 8;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScaling = 0.75f;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning;

    private void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = enemiesGroupSize;
    }

    int EnemiesPerWave()
    {
        return Mathf.RoundToInt(enemiesGroupSize * Mathf.Pow(currentWave, difficultyScaling));
    }

    void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSeccond))
        {
            Debug.Log("Enemy spawn");
        }
    }
}
