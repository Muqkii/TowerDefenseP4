using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

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

    Vector3 endLocation;
    Transform actualPos;


    public Text currentWaveText;
    public Text waveTimerText;
    public Text pressEnterToSkip;

    public Wave[] waves;
    int waveLength;
    int currentWave;
    int currentGroup;
    int currentEnemy;

    bool gameEnd;

    GameObject obj;
    void Start()
    {
        waveLength = waves.Length;
        timerWave = waves[currentWave].waveSpawnDelay;
        NumberToText(currentWaveText, currentWave);
    }

    void Update()
    {
        WaveManagement();
        WaveSkip();
        SkipTimer();
    }
    void WaveManagement()
    {
        if (!gameEnd)
        {
            if ( itsWavingTime )
            {
                EnemySpawning();
            } else
            {
                timerWave -= Time.deltaTime;
                NumberToText(waveTimerText, timerWave);
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
                NumberToText(currentWaveText, currentWave);
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
                        obj = Instantiate(waves[currentWave].enemiesToSpawn[currentGroup]);

                        obj.GetComponent<SplineAnimate>().Container = thePath;
                        currentEnemy++;
                        timerEnemy = waves[currentWave].enemySpawnDelay;
                    }
                }
            }
        }
    }


    void WaveSkip()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            timerWave = 0;
        }
        //if button pressed skip wave timer
    }

    void NumberToText(Text text, float number)
    {
        int newNumber = (int)number;
        text.text = newNumber.ToString();
    }

    void SkipTimer()
    {
        if (!itsWavingTime)
        {
            pressEnterToSkip.text = "Press the 'enter' key to skip timer";
        }
        else
        {
            pressEnterToSkip.text = "";
        }
    }

}
