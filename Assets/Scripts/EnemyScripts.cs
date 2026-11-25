using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    public float health = 50.0f;

    protected Rigidbody2D body;
    protected SpriteRenderer enemySprite;
    protected Camera gameCamera;

    protected virtual void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        gameCamera = Camera.main;
    }

    private void TakeDamage(int value)
    {
        health -= value;

        if (health <= 0f)
        {
            Die();
        }

        Debug.Log("Enemy Health : " + health);
    }

    public void TakeDamage(float ratio)
    {
        health -= (int)(health * ratio);

        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        //EventManager.RungEnemyDieEvent();
        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            coll.gameObject.SetActive(false);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            TakeDamage(20);
        }
    }

    protected void RemoveIfBelowScreen()
    {
        if (gameCamera == null || enemySprite == null)
            return;

        float bottom = gameCamera.transform.position.y
                       - gameCamera.orthographicSize;

        if (enemySprite.bounds.max.y < bottom)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void LateUpdate()
    {
        RemoveIfBelowScreen();
    }

    public virtual void Move()
    {
    }
}