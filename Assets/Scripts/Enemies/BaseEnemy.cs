using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public GameObject battleController;

    public EnemyType type;
    public int health;
    public int expValue;
    public float speed = 1.0f;

    private void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    private void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health -= collision.gameObject.GetComponentInParent<PlayableCharacter>().AttackValue;
            if (health < 0)
            {
                battleController.SendMessage("OnEnemyDeath", new EnemyModel
                {
                    enemyType = type,
                    experienceGain = expValue
                });

                transform.position = new Vector3(13, 0, 0);
                //gameObject.SetActive(false);
            }
        }
    }

    public void OnDamageTaken(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            battleController.SendMessage("OnEnemyDeath", new EnemyModel
            {
                enemyType = type,
                experienceGain = expValue
            });
        }
    }
}
