using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public GameObject battleController;

    public EnemyType type;
    public int health;
    public int expValue;

    void OnTriggerEnter2D(Collider2D collision)
    {
        health -= collision.gameObject.GetComponentInParent<PlayableCharacter>().AttackValue;
        if(health < 0)
        {
            battleController.SendMessage("OnEnemyDeath", new EnemyModel
            {
                enemyType = type,
                experienceGain = expValue
            });

            gameObject.SetActive(false);
        }
    }

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
