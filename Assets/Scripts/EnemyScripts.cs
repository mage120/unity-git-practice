using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Warning,
        Charge
    }

    [Header("Timing")]
    [SerializeField] float idleTime = 5f;
    [SerializeField] float warningTime = 1.5f;

    [Header("Movement")]
    [SerializeField] float shakeAmount = 0.08f;
    [SerializeField] float shakeSpeed = 35f;
    [SerializeField] float chargeSpeed = 15f;

    [Header("Health")]
    [SerializeField] float maxHealth = 100f;

    [Header("Shooting")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 100f;
    [SerializeField] float fireInterval = 1f;

    [Header("Effects")]
    [SerializeField] GameObject explosionPrefab;

    private Animator animator;
    private Coroutine blinkCoroutine;
    private bool isDead = false;

    private float fireTimer;

    private float currentHealth;
    private float stateTimer;
    private Vector3 originalPosition;

    private EnemyState currentState = EnemyState.Idle;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        stateTimer += Time.deltaTime;

        switch (currentState)
        {
            case EnemyState.Idle:
                if (stateTimer >= idleTime ||
                    currentHealth <= maxHealth * 0.2f)
                {
                    ChangeState(EnemyState.Warning);
                }

                fireTimer += Time.deltaTime;

                if (fireTimer >= fireInterval)
                {
                    Fire();
                    fireTimer = 0f;
                }

                break;

            case EnemyState.Warning:
                float shake = Mathf.Sin(
                    stateTimer * shakeSpeed
                ) * shakeAmount;

                transform.position =
                    originalPosition + Vector3.right * shake;

                if (stateTimer >= warningTime)
                {
                    transform.position = originalPosition;
                    ChangeState(EnemyState.Charge);
                }
                break;

            case EnemyState.Charge:
                transform.position +=
                    Vector3.down * chargeSpeed * Time.deltaTime;
                break;
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
            return;
        }

        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
        }

        blinkCoroutine = StartCoroutine(BlinkEffect());
    }

    void ChangeState(EnemyState newState)
    {
        currentState = newState;
        stateTimer = 0f;

        if (newState == EnemyState.Warning)
        {
            originalPosition = transform.position;
        }
    }

    void Fire()
    {
        if (bulletPrefab == null) return;

        GameObject bullet = Instantiate(
            bulletPrefab,
            transform.position,
            Quaternion.identity
        );

        bullet.GetComponent<Bullet>().owner =
            Bullet.BulletOwner.Enemy;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.down * bulletSpeed;
        }
    }

    System.Collections.IEnumerator BlinkEffect()
    {
        animator.SetBool("Blink", true);

        yield return new WaitForSeconds(0.2f);

        animator.SetBool("Blink", false);
        blinkCoroutine = null;
    }

    void Die()
    {
        isDead = true;

        if (explosionPrefab != null)
        {
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        Destroy(gameObject);
    }
}