using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public BattleController battleController;

    public EnemyType type;
    public int health;
    public int expValue;


    //TODO : Add something to track whether or not we got hit here

    public void OnDamageTaken(int damage)
    {
        health -= damage;
        if(health < 0)
        {
            battleController.SendMessage("OnEnemyDeath", new EnemyModel
            {
                enemyType = type,
                experienceGain = expValue
            });
        }
    }
}
