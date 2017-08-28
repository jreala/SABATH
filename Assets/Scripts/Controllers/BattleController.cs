using UnityEngine;

public class BattleController : MonoBehaviour
{
    public int SmallCounter = 0;
    public int MediumCounter = 0;
    public int LargeCounter = 0;
    public int BossCounter = 0;

    public void OnEnemyDeath(EnemyModel model)
    {
        Debug.Log("On Enemy Death Hit");
        switch (model.enemyType)
        {
            case EnemyType.Small:
                SmallCounter++;
                break;
            case EnemyType.Medium:
                MediumCounter++;
                break;
            case EnemyType.Large:
                LargeCounter++;
                break;
            case EnemyType.Boss:
                BossCounter++;
                break;
            default:
                Debug.LogError($"Error processing enemy type ---- {model.enemyType}");
                break;
        }
    }
}
