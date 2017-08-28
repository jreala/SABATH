using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject enemyObject;

    public int smallSpawner     = 0;
    public int mediumSpawner    = 0;
    public int largeSpawner     = 0;

    public int maxOnscreen      = 20;
    public float spawnTime      = 3f;

    struct SpawnerInternals_s
    {
        public int smallSpawnCounter;           //Tracks Small enemy objects spawned
        public int mediumSpawnCounter;          //Tracks Medium enemy objects spawned
        public int largeSpawnCounter;           //Tracks Large enemy objects spawned
        public GameObject[] spawnedObjects;     //List of objects spawned
        public int curObjects;                  //Current objects spawned
        public int spawnObjects;                //Total objects to be spawned
        public int maxObjects;                  //Maximum spawned objects allowed
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
        Spawn();
    }

    void InitializeSpawnCounters()
    {
        spawnData.smallSpawnCounter     = smallSpawner;
        spawnData.mediumSpawnCounter    = mediumSpawner;
        spawnData.largeSpawnCounter     = largeSpawner;
        spawnData.spawnObjects          = smallSpawner + mediumSpawner + largeSpawner;

        spawnData.curObjects            = 0;
        spawnData.spawnedObjects        = new GameObject[maxOnscreen];
        spawnData.maxObjects            = maxOnscreen;
    }

    //Spawns in enemy objects, but will need to be repositioned and then activated
    //Use spawnData.spawnedObjects array
    void Spawn()
    {
        Vector3 spawnPos = new Vector3(13, 0, 0);

        while (spawnData.curObjects < spawnData.spawnObjects)
        {
            if (spawnData.smallSpawnCounter-- > 0)
            {
                Debug.Log($"Spawn small enemy ({spawnData.smallSpawnCounter} left)");
                spawnData.spawnedObjects[spawnData.curObjects] = Instantiate(enemyObject, spawnPos, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawnData.spawnedObjects[spawnData.curObjects].transform.parent = transform;
                spawnData.spawnedObjects[spawnData.curObjects].GetComponent<BaseEnemy>().type = EnemyType.Small;
            }
            else if (spawnData.mediumSpawnCounter-- > 0)
            {
                Debug.Log($"Spawn medium enemy ({spawnData.mediumSpawnCounter} left)");
                spawnData.spawnedObjects[spawnData.curObjects] = Instantiate(enemyObject, spawnPos, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawnData.spawnedObjects[spawnData.curObjects].transform.parent = transform;
                spawnData.spawnedObjects[spawnData.curObjects].GetComponent<BaseEnemy>().type = EnemyType.Medium;
            }
            else if (spawnData.largeSpawnCounter-- > 0)
            {
                Debug.Log($"Spawn large enemy ({spawnData.largeSpawnCounter} left)");
                spawnData.spawnedObjects[spawnData.curObjects] = Instantiate(enemyObject, spawnPos, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawnData.spawnedObjects[spawnData.curObjects].transform.parent = transform;
                spawnData.spawnedObjects[spawnData.curObjects].GetComponent<BaseEnemy>().type = EnemyType.Large;
            }
            else
            {
                Debug.LogError("Invalid enemy type to spawn");
            }
            spawnData.curObjects++;
        }
    }
    
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
