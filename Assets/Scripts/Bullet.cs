using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletOwner
    {
        Player,
        Enemy
    }

    public BulletOwner owner;
    public float damage = 10f;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (owner == BulletOwner.Player)
        {
            if (other.CompareTag("Enemy"))
            {
                EnemyScripts enemy =
                    other.GetComponent<EnemyScripts>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
        }
        else if (owner == BulletOwner.Enemy)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController player =
                    other.GetComponent<PlayerController>();

                if (player != null)
                {
                    player.TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}