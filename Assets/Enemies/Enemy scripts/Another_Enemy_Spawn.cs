using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Splines;

public class Another_Enemy_Spawn : MonoBehaviour
{
    [System.Serializable]
    public struct Wave
    {
        public GameObject[] enemiesToSpawn;
        public int[] groupsSpawnSize;
        public float enemySpawnDelay;
        public float groupSpawnDelay;
        public float waveSpawnDelay;
    }

    public SplineContainer thePath;

    private bool itsWavingTime;
    float timerWave;
    float timerEnemy;
    float timerGroup;

    Vector3 spawnPosition;
    Transform actualPos;
    
    public Wave[] waves;
    int waveLength;
    int currentWave;
    int currentGroup;
    int currentEnemy;

    int enemiesSpawned;

    bool gameEnd;

    void Start()
    {
        waveLength = waves.Length;
        //spawnPosition = thePath.;
        timerWave = waves[currentWave].waveSpawnDelay;
        //timerEnemy = waves[currentWave].enemySpawnDelay;
        //timerGroup = waves[currentWave].groupSpawnDelay;
        var knot = thePath.Spline.ToArray()[0];
        spawnPosition = knot.Position;
        actualPos.position = spawnPosition;
    }

    void Update()
    {
        WaveManagement();
    }

    /*void EnemySpawning()
    {
        for (int j = 0; j < waves[currentWave].enemiesToSpawn.Length; j++)
        {
            timerGroup -= Time.deltaTime;
            if(timerGroup < 0)
            {
                for(int i = 0; i < waves[currentWave].groupsSpawnSize[currentGroup]; i++) 
                {
                    timerEnemy -= Time.deltaTime;
                    if(timerEnemy < 0)
                    {
                        Instantiate(waves[currentWave].enemiesToSpawn[currentGroup]);
                    }
                }
                currentGroup++;
            }
        }
        currentWave++;
        itsWavingTime = false;
    }*/

    void EnemySpawning()
    {
        if(currentGroup >= waves[currentWave].groupsSpawnSize.Length)
        {
            if (currentWave + 1 >= waves.Length)
            {
                gameEnd = true;
            }
            else if(currentWave < waves.Length)
            {
                currentGroup = 0;
                itsWavingTime = false;
                timerWave = waves[currentWave].waveSpawnDelay;
                currentWave++;
            }
        }
        else if (currentGroup < waves[currentWave].enemiesToSpawn.Length)
        {
            timerGroup -= Time.deltaTime;
            if (timerGroup < 0.0f)
            {
                if (currentEnemy >= waves[currentWave].groupsSpawnSize[currentGroup])
                {
                    currentGroup++;
                    currentEnemy = 0;
                    timerGroup = waves[currentWave].groupSpawnDelay;
                    timerEnemy = waves[currentWave].enemySpawnDelay;
                }
                else if (currentEnemy < waves[currentWave].groupsSpawnSize[currentGroup])
                {

                    timerEnemy -= Time.deltaTime;
                    if (timerEnemy < 0.0f)
                    {
                        GameObject obj = Instantiate(waves[currentWave].enemiesToSpawn[currentGroup], actualPos);

                        obj.GetComponent<SplineAnimate>().Container = thePath;

                        //GameObject obj = SplineInstantiate.Instantiate<GameObject>(waves[currentWave].enemiesToSpawn[currentGroup]);

                        //SplineAnimate(obj);
                        //obj.transform.position = spawnPosition;

                        currentEnemy++;

                        /*if(currentEnemy + 1 < waves[currentWave].enemiesToSpawn.Length)
                        {
                            currentEnemy++;
                        }
                        else
                        {
                            currentEnemy = 0;
                            currentGroup++;
                        }*/
                        timerEnemy = waves[currentWave].enemySpawnDelay;
                    }
                }
            }
        }
    }

    void WaveManagement()
    {
        if (!gameEnd)
        {
            if ( itsWavingTime )
            {
                EnemySpawning();
            } else if ( !itsWavingTime )
            {
                timerWave -= Time.deltaTime;
                if( timerWave < 0.0f)
                {
                    itsWavingTime = true;
                }
            }
        }
        else
        {
            Debug.Log("Game End");
        }
    }
}
