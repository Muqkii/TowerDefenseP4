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
    public Text pressEnterToStart;
    public Text untilNextWave;
    public Text nextEnemies;
    public Text nextEnemiesText;

    public Wave[] waves;
    int waveLength;
    int currentWave;
    int currentGroup;
    int currentEnemy;

    int currentTextEnemy;

    bool gameEnd;

    bool gameStart;

    bool waveStarted;

    GameObject obj;
    Transform spawnpoint;
    void Start()
    {
        timerWave = waves[currentWave].waveSpawnDelay;
        NumberToText(currentWaveText, currentWave);
        nextEnemiesText.enabled = false;
    }

    void Update()
    {
        WaveManagement();
        WaveSkip();
        SkipTimer();
        spawnpoint = GameObject.Find("Spawnpoint").transform;
        NextEnemies();
        NewNumberToText(currentWaveText, currentWave + 1);
    }
    void WaveManagement()
    {
        if (gameStart)
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
                        waveStarted = true;
                    }
                }
            }
            else
            {
                Debug.Log("Game End");
            }
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

                        obj.GetComponent<Spline_Movement>().thePath = thePath;
                        currentEnemy++;
                        timerEnemy = waves[currentWave].enemySpawnDelay;
                    }
                }
            }
        }
    }


    void WaveSkip()
    {
        if (gameStart)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                timerWave = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameStart = true;
            }
        }

        //if button pressed skip wave timer
    }

    void NumberToText(Text text, float number)
    {
        int newNumber = (int)number;
        text.text = newNumber.ToString();
    }

    void NewNumberToText(Text text, float number)
    {
        int newNumber = (int)number;
        text.text = newNumber.ToString() + " / " + waves.Length;
    }


    void SkipTimer()
    {
        if (!gameStart)
        {
            pressEnterToStart.text = "Press the 'enter' key to start the game";
        }
        else
        {
            pressEnterToStart.text = "";
            nextEnemiesText.enabled = true;
            waveStarted = true;
        }

        if (!itsWavingTime && gameStart)
        {
            pressEnterToSkip.text = "Press the 'enter' key to skip timer";
            untilNextWave.text = "Time until next wave";
        }
        else
        {
            pressEnterToSkip.text = "";
        }
    }


    void NextEnemies()
    {
        if (waveStarted)
        {
            nextEnemies.text = " ";
            for (int i = 0; i < waves[currentWave].enemiesToSpawn.Length; i++)
            {
                nextEnemies.text += waves[currentWave].enemiesToSpawn[i].name + " X " + waves[currentWave].groupsSpawnSize[i] + "\n";
            }
            waveStarted = false;
        }

        
    }
}
