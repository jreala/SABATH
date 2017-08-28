using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject smallEnemy;
    public GameObject mediumEnemy;
    public GameObject largeEnemy;

    public int smallSpawner     = 0;
    public int mediumSpawner    = 0;
    public int largeSpawner     = 0;

    public float spawnTime = 3f;

    struct SpawnerInternals_s
    {
        public int smallSpawnCounter;
        public int mediumSpawnCounter;
        public int largeSpawnCounter;
        public GameObject[] spawnedObjects;
        public int objectsCount;
    };
    private SpawnerInternals_s spawnData;

    struct BattleCounter_s
    {
        public int SmallCounter;
        public int MediumCounter;
        public int LargeCounter;
        public int BossCounter;
    };
    private BattleCounter_s battleCounters;

    private void Start()
    {
        InitializeSpawnCounters();

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void InitializeSpawnCounters()
    {
        spawnData.smallSpawnCounter     = smallSpawner;
        spawnData.mediumSpawnCounter    = mediumSpawner;
        spawnData.largeSpawnCounter     = largeSpawner;
    }

    void Spawn()
    {
        //TODO: Should also add feature so we can scale the enemy's size 
        //so we can re-use the same enemy but scale their size alongside with HP

        //TODO: Tweak spawnPos based off the GameObject
        Vector3 spawnPos = new Vector3(13, 0, 0);

        if (spawnData.smallSpawnCounter-- > 0)
        {
            Debug.Log($"Spawn small enemy ({spawnData.smallSpawnCounter} left)");
            spawnData.spawnedObjects[spawnData.objectsCount++] = Instantiate(smallEnemy, spawnPos, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        else if (spawnData.mediumSpawnCounter-- > 0)
        {
            Debug.Log($"Spawn medium enemy ({spawnData.mediumSpawnCounter} left)");
            spawnData.spawnedObjects[spawnData.objectsCount++] = Instantiate(mediumEnemy, spawnPos, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        else if (spawnData.largeSpawnCounter-- > 0)
        {
            Debug.Log($"Spawn large enemy ({spawnData.largeSpawnCounter} left)");
            spawnData.spawnedObjects[spawnData.objectsCount++] = Instantiate(largeEnemy, spawnPos, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }

    //Could pass the GameObject* to disable the GameObject if enough small/medium/large enemies defeated?
    public void OnEnemyDeath(EnemyModel model)
    {
        Debug.Log("On Enemy Death Hit");
        switch (model.enemyType)
        {
            case EnemyType.Small:
                battleCounters.SmallCounter++;
                break;
            case EnemyType.Medium:
                battleCounters.MediumCounter++;
                break;
            case EnemyType.Large:
                battleCounters.LargeCounter++;
                break;
            case EnemyType.Boss:
                battleCounters.BossCounter++;
                break;
            default:
                Debug.LogError($"Error processing enemy type ---- {model.enemyType}");
                break;
        }
    }
}
