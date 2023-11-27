using System;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    [SerializeField] private ShipData playerShip;
    [SerializeField] private PanelControl panelClass;
    [SerializeField] private EnemySpawner enemySpawnClass;
    private static GameInstance thisInstance;
    public static GameInstance Instance { get { return thisInstance; } }

    private GameModes gameMode;

    public GameModes GameModeProperty
    {
        get { return gameMode; }
        set
        {
            gameMode = value;
            if(value ==  GameModes.PLAY)
            {
                CalculateSession();
                CalculateSpawnInterval();
                enemySpawnClass.SpawnEnemy();
            }
        }
    }

    private float gameSession = 1f;
    private float enemySpawnInterval = 5f;
    private float sessionInSeconds;
    private float timeElapsed = 0f;

    private void Awake()
    {
        if (thisInstance != null && thisInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            thisInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void CalculateSession()
    {
        sessionInSeconds = gameSession * 60;
    }

    void CalculateSpawnInterval()
    {
        enemySpawnClass.spawnInterval = enemySpawnInterval;
    }

    public void ChangeData(DataTypes data, float value)
    {
        switch(data)
        {
            case DataTypes.GAMESESSION:
                gameSession = value;
                break;
            case DataTypes.ENEMYSPAWN:
                enemySpawnInterval = value;
                break;
        }
    }

    void Update()
    {
        if(GameModeProperty == GameModes.PLAY)
        {
            timeElapsed += Time.deltaTime;
            if(sessionInSeconds < timeElapsed)
            {
                EndSession();
            }
        }
    }

    public void EndSession()
    {
        GameModeProperty = GameModes.MENU;
        panelClass.EndSession();
    }

    public void ResetGame()
    {
        playerShip.Reset();
        enemySpawnClass.Reset();
    }
}

public enum GameModes
{
    MENU,
    PLAY
}
