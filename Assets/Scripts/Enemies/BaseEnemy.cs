using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private GameObject battleController;

    public EnemyType type;
    public int health;
    public int expValue;
    public float speed = 3f;

    private void Start()
    {
        //gameObject.SetActive(false);
        battleController = this.transform.parent.gameObject;

        switch (type)
        {
            case EnemyType.Small:
                break;
            case EnemyType.Medium:
                transform.localScale += new Vector3(1, 1, 0);
                break;
            case EnemyType.Large:
                transform.localScale += new Vector3(3, 3, 0);
                break;
            default:
                Debug.LogError($"Unknown size for type: {type}");
                break;
        }
    }

    private void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        float posVariance = Random.Range(0.0f, 10.0f);

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

                transform.position = new Vector3(13 + posVariance, 0, 0);
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
