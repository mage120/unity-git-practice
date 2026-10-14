using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // public 외부 공용, private 비공개
      
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;
    [Header("Health")]
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0);
        transform.position += direction.normalized * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                GameObject bullet = Instantiate(
                    bulletPrefab,
                    transform.position + new Vector3(x * 0.3f, y * 0.3f, 0),
                    Quaternion.identity
                );

                bullet.GetComponent<Bullet>().owner =
                    Bullet.BulletOwner.Player;

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.linearVelocity = Vector2.up * bulletSpeed;
                }
            }
        }
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

}

/* 가로 세발짜리
void Fire()
{
    for (int i = -1; i <= 1; i++)
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            transform.position + new Vector3(i * 0.3f, 0, 0),
            Quaternion.identity
        );

        bullet.GetComponent<Bullet>().owner =
            Bullet.BulletOwner.Player;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * bulletSpeed;
        }
    }
}
 */

/*
for(int i = 0; i < 3; i++)
{
GameObject bullet = Instantiate(bulletPrefab);
Vector3 bulletPos = transform.position;
bulletPos.y += 0.3f * i;
bullet.transform.position = bulletPos;
bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
}
 */